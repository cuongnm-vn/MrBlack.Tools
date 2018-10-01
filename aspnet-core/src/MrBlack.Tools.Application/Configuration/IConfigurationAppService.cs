using System.Threading.Tasks;
using MrBlack.Tools.Configuration.Dto;

namespace MrBlack.Tools.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
