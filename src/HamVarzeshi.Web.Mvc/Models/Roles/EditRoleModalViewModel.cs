using Abp.AutoMapper;
using HamVarzeshi.Roles.Dto;
using HamVarzeshi.Web.Models.Common;

namespace HamVarzeshi.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
