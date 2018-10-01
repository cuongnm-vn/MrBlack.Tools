using System.Threading.Tasks;
using Abp.Application.Services;
using MrBlack.Tools.Authorization.Accounts.Dto;

namespace MrBlack.Tools.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
