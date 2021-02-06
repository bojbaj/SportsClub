using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace HamVarzeshi.Authorization
{
    public class HamVarzeshiAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Clubs, L("Clubs"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, HamVarzeshiConsts.LocalizationSourceName);
        }
    }
}
