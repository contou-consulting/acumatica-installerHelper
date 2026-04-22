using System.Management.Automation;
using AcumaticaInstallerHelper.Models;

namespace AcumaticaInstallerHelper.CLI
{
    [Cmdlet(VerbsCommon.Get, "AcumaticaConfig")]
    [OutputType(typeof(object))]
    public class GetAcumaticaConfigCmdlet : AcumaticaBaseCmdlet
    {
        protected override void ProcessRecord()
        {
            try
            {
                var config = new
                {
                    AcumaticaDirectory = AcumaticaManager.GetAcumaticaDirectory(),
                    SiteDirectory = AcumaticaManager.GetSiteDirectory(),
                    VersionDirectory = AcumaticaManager.GetVersionDirectory(),
                    DefaultSiteType = AcumaticaManager.GetDefaultSiteType(),
                    InstallDebugTools = AcumaticaManager.GetInstallDebugTools(),
                    DBServerName = AcumaticaManager.GetDBServerName(),
                    DBServerAuth = AcumaticaManager.GetDBServerAuth(),
                    DBServerUsername = AcumaticaManager.GetDBServerUsername(),
                    DBServerPasswordSet = AcumaticaManager.HasDBServerPassword()
                };
                
                WriteObject(config);
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "GetConfigException", ErrorCategory.NotSpecified, null));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "AcumaticaDirectory")]
    [OutputType(typeof(void))]
    public class SetAcumaticaDirectoryCmdlet : AcumaticaBaseCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "New Acumatica base directory path")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; } = string.Empty;

        protected override void ProcessRecord()
        {
            try
            {
                AcumaticaManager.SetAcumaticaDirectory(Path);
                WriteInformation($"Acumatica directory set to: {Path}", new string[] { "Success" });
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "SetAcumaticaDirectoryException", ErrorCategory.NotSpecified, Path));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "AcumaticaSiteDirectory")]
    [OutputType(typeof(void))]
    public class SetAcumaticaSiteDirectoryCmdlet : AcumaticaBaseCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "New site directory path")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; } = string.Empty;

        protected override void ProcessRecord()
        {
            try
            {
                AcumaticaManager.SetSiteDirectory(Path);
                WriteInformation($"Site directory set to: {Path}", new string[] { "Success" });
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "SetSiteDirectoryException", ErrorCategory.NotSpecified, Path));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "AcumaticaVersionDirectory")]
    [OutputType(typeof(void))]
    public class SetAcumaticaVersionDirectoryCmdlet : AcumaticaBaseCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "New version directory path")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; } = string.Empty;

        protected override void ProcessRecord()
        {
            try
            {
                AcumaticaManager.SetVersionDirectory(Path);
                WriteInformation($"Version directory set to: {Path}", new string[] { "Success" });
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "SetVersionDirectoryException", ErrorCategory.NotSpecified, Path));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "AcumaticaDefaultSiteType")]
    [OutputType(typeof(void))]
    public class SetAcumaticaDefaultSiteTypeCmdlet : AcumaticaBaseCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Site type (Production or Development)")]
        [ValidateSet("Production", "Development")]
        public SiteType SiteType { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                AcumaticaManager.SetDefaultSiteType(SiteType);
                WriteInformation($"Default site type set to: {SiteType}", new string[] { "Success" });
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "SetDefaultSiteTypeException", ErrorCategory.NotSpecified, SiteType));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "AcumaticaInstallDebugTools")]
    [OutputType(typeof(void))]
    public class SetAcumaticaInstallDebugToolsCmdlet : AcumaticaBaseCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Install debug tools by default")]
        public bool InstallDebugTools { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                AcumaticaManager.SetInstallDebugTools(InstallDebugTools);
                WriteInformation($"Install debug tools set to: {InstallDebugTools}", new string[] { "Success" });
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "SetInstallDebugToolsException", ErrorCategory.NotSpecified, InstallDebugTools));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "AcumaticaDBServerName")]
    [OutputType(typeof(void))]
    public class SetAcumaticaDBServerNameCmdlet : AcumaticaBaseCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "SQL Server host name or instance (e.g. localhost, SERVER01\\SQLEXPRESS)")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; } = string.Empty;

        protected override void ProcessRecord()
        {
            try
            {
                AcumaticaManager.SetDBServerName(ServerName);
                WriteInformation($"DB server name set to: {ServerName}", new string[] { "Success" });
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "SetDBServerNameException", ErrorCategory.NotSpecified, ServerName));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "AcumaticaDBServerAuth")]
    [OutputType(typeof(void))]
    public class SetAcumaticaDBServerAuthCmdlet : AcumaticaBaseCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Management auth mode used to create/modify the database (Windows or SQL)")]
        [ValidateSet("Windows", "SQL")]
        public DBServerAuthType AuthType { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                AcumaticaManager.SetDBServerAuth(AuthType);
                WriteInformation($"DB server auth set to: {AuthType}", new string[] { "Success" });
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "SetDBServerAuthException", ErrorCategory.NotSpecified, AuthType));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "AcumaticaDBServerCredential")]
    [OutputType(typeof(void))]
    public class SetAcumaticaDBServerCredentialCmdlet : AcumaticaBaseCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "SQL login used for management operations (only applies when DBServerAuth is SQL). Prompt with Get-Credential.")]
        [ValidateNotNull]
        [Credential]
        public PSCredential Credential { get; set; } = PSCredential.Empty;

        protected override void ProcessRecord()
        {
            try
            {
                string username = Credential.UserName;
                string password = new System.Net.NetworkCredential(string.Empty, Credential.Password).Password;

                AcumaticaManager.SetDBServerUsername(username);
                AcumaticaManager.SetDBServerPassword(password);
                WriteInformation($"DB server credential set for user: {username}", new string[] { "Success" });
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "SetDBServerCredentialException", ErrorCategory.NotSpecified, Credential.UserName));
            }
        }
    }

    [Cmdlet(VerbsCommon.Clear, "AcumaticaDBServerCredential")]
    [OutputType(typeof(void))]
    public class ClearAcumaticaDBServerCredentialCmdlet : AcumaticaBaseCmdlet
    {
        protected override void ProcessRecord()
        {
            try
            {
                AcumaticaManager.SetDBServerUsername(string.Empty);
                AcumaticaManager.SetDBServerPassword(string.Empty);
                WriteInformation("DB server credential cleared.", new string[] { "Success" });
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "ClearDBServerCredentialException", ErrorCategory.NotSpecified, null));
            }
        }
    }
}