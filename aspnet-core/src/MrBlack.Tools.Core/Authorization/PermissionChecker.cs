using Abp.Authorization;
using MrBlack.Tools.Authorization.Roles;
using MrBlack.Tools.Authorization.Users;

namespace MrBlack.Tools.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
