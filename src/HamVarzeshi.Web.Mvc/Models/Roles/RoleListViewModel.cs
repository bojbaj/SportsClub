using System.Collections.Generic;
using HamVarzeshi.Roles.Dto;

namespace HamVarzeshi.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
