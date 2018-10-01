using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MrBlack.Tools.Authorization;

namespace MrBlack.Tools
{
    [DependsOn(
        typeof(ToolsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MrBlackApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ToolsAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MrBlackApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
