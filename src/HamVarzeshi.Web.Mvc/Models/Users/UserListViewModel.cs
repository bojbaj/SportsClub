using System.Collections.Generic;
using HamVarzeshi.Roles.Dto;

namespace HamVarzeshi.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
