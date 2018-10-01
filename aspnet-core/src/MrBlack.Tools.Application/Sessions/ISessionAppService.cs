using System.Threading.Tasks;
using Abp.Application.Services;
using MrBlack.Tools.Sessions.Dto;

namespace MrBlack.Tools.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
