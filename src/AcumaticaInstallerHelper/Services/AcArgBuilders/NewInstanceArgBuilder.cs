using AcumaticaInstallerHelper.Models;

namespace AcumaticaInstallerHelper.Services.AcArgBuilders;

public class NewInstanceArgBuilder : IAcArgBuilder
{
    public IEnumerable<string> BuildArgs(SiteConfiguration siteConfig)
    {
        var args = new List<string>
        {
            "-configmode:NewInstance",
            $"-iname:\"{siteConfig.SiteName}\"",
            $"-ipath:\"{siteConfig.SitePath}\"",
            $"-dbsrvname:\"{siteConfig.DBServer}\"",
            $"-dbname:\"{siteConfig.DBName}\"",
        };

        if (siteConfig.DBServerAuth == DBServerAuthType.SQL)
        {
            args.Add("-dbsrvwinauth:False");
            args.Add($"-dbsrvuser:\"{siteConfig.DBServerUsername}\"");
            args.Add($"-dbsrvpass:\"{siteConfig.DBServerPassword}\"");
        }
        else
        {
            args.Add("-dbsrvwinauth:True");
        }

        args.AddRange(new[]
        {
            $"-swebsite:\"{siteConfig.IISWebsite}\"",
            $"-svirtdir:\"{siteConfig.SiteName}\"",
            $"-spool:\"{siteConfig.IISAppPool}\"",
            "-output:Quiet",
            "-company:\"CompanyID=1;CompanyType=;LoginName=;\"",
            "-company:\"CompanyID=2;CompanyType=SalesDemo;ParentID=1;Visible=Yes;LoginName=Company;\"",
        });

        if (siteConfig.IsPortal)
        {
            args.Add("-portal");
        }

        if (siteConfig.SiteType == SiteType.Development)
        {
            args.Add("-developmentmode");
        }

        return args;
    }
}