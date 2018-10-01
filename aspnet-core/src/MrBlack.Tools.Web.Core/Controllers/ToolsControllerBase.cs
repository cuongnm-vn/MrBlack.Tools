using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MrBlack.Tools.Controllers
{
    public abstract class ToolsControllerBase: AbpController
    {
        protected ToolsControllerBase()
        {
            LocalizationSourceName = ToolsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
