using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MrBlack.Tools.Configuration.Dto;

namespace MrBlack.Tools.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MrBlackAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
