using System.Collections.Generic;
using HamVarzeshi.Roles.Dto;

namespace HamVarzeshi.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}