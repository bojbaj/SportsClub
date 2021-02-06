using Abp.Authorization;
using HamVarzeshi.Authorization.Roles;
using HamVarzeshi.Authorization.Users;

namespace HamVarzeshi.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
