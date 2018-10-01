using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MrBlack.Tools.Configuration;

namespace MrBlack.Tools.Web.Host.Startup
{
    [DependsOn(
       typeof(ToolsWebCoreModule))]
    public class ToolsWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ToolsWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ToolsWebHostModule).GetAssembly());
        }
    }
}
