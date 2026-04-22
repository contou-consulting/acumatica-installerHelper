using System.Text.Json.Serialization;

namespace AcumaticaInstallerHelper.Models;

/// <summary>
///     Module configuration defaults loaded from JSON
/// </summary>
public class ModuleConfiguration
{
    [JsonPropertyName("AcumaticaDir")]
    public string AcumaticaDirectory { get; set; } = @"C:\Acumatica";

    [JsonPropertyName("AcumaticaSiteDir")]
    public string SiteDirectory { get; set; } = "Sites";

    [JsonPropertyName("AcumaticaVersionDir")]
    public string VersionDirectory { get; set; } = "Versions";

    [JsonPropertyName("SiteType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SiteType DefaultSiteType { get; set; } = SiteType.Production;

    [JsonPropertyName("InstallDebugTools")]
    public bool InstallDebugTools { get; set; } = false;

    [JsonPropertyName("DBServerName")]
    public string DBServerName { get; set; } = "localhost";

    [JsonPropertyName("DBServerAuth")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DBServerAuthType DBServerAuth { get; set; } = DBServerAuthType.Windows;

    [JsonPropertyName("DBServerUsername")]
    public string DBServerUsername { get; set; } = string.Empty;

    [JsonPropertyName("DBServerPassword")]
    public string DBServerPassword { get; set; } = string.Empty;
}

public enum DBServerAuthType
{
    Windows,
    SQL
}