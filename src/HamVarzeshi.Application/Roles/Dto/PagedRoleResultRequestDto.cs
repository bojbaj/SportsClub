using Abp.Application.Services.Dto;

namespace HamVarzeshi.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

