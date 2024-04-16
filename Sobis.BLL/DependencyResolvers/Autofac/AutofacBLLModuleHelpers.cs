using Microsoft.Extensions.Configuration;
using Sobis.Core.Entities.Concrete;
using Sobis.Core.Securitiy.JWT;
using Sobis.Entities.StaticVariable;

internal static class AutofacBLLModuleHelpers
{

    public static void SetStaticSettings()
    {
        var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        Dboptions.DbType = appSettings["SbsDbOptions:DbType"];
        Dboptions.DbName = appSettings["SbsDbOptions:DbName"];
        Dboptions.DbUser = appSettings["SbsDbOptions:DbUser"];
        Dboptions.DbPassword = appSettings["SbsDbOptions:DbPassword"];

        TokenOptionsStatic.Issuer = appSettings["SbsTokenOptions:Issuer"];
        TokenOptionsStatic.Audience = appSettings["SbsTokenOptions:Audience"];
        TokenOptionsStatic.AccessTokenExpiration = int.Parse(appSettings["SbsTokenOptions:AccessTokenExpiration"]);
        TokenOptionsStatic.SecurityKey = appSettings["SbsTokenOptions:SecurityKey"];

        SysVariable.WebApiBaseAdres= appSettings["WebApiOptions:WebApiBaseAdres"];
        SysVariable.WebApiBasePort= appSettings["WebApiOptions:WebApiBasePort"];
    }
}