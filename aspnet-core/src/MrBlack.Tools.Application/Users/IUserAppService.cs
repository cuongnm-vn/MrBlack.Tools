using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MrBlack.Tools.Abp.Application.Services.Dto;
using MrBlack.Tools.Roles.Dto;
using MrBlack.Tools.Users.Dto;

namespace MrBlack.Tools.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedFilterAndSortedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
