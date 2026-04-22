using System.Security.Cryptography;
using System.Text;

namespace AcumaticaInstallerHelper.Services;

/// <summary>
///     DPAPI-backed protection for secrets stored in the config file.
///     Scope is CurrentUser so ciphertext is only readable on this machine by the user who set it.
/// </summary>
internal static class CredentialProtector
{
    private const string Prefix = "DPAPI:";
    private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("AcumaticaInstallerHelper.DBServerCredential.v1");

    public static string Protect(string plaintext)
    {
        if (string.IsNullOrEmpty(plaintext))
            return string.Empty;

        byte[] cipher = ProtectedData.Protect(
            Encoding.UTF8.GetBytes(plaintext),
            Entropy,
            DataProtectionScope.CurrentUser);

        return Prefix + Convert.ToBase64String(cipher);
    }

    public static string Unprotect(string stored)
    {
        if (string.IsNullOrEmpty(stored))
            return string.Empty;

        if (!stored.StartsWith(Prefix, StringComparison.Ordinal))
            throw new CryptographicException("Stored credential is not in the expected protected format. Use Set-AcumaticaDBServerCredential to (re)set it — the config file must not be edited by hand.");

        byte[] cipher = Convert.FromBase64String(stored.Substring(Prefix.Length));
        byte[] plain  = ProtectedData.Unprotect(cipher, Entropy, DataProtectionScope.CurrentUser);
        return Encoding.UTF8.GetString(plain);
    }
}
