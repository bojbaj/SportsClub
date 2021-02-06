using Abp.Application.Services.Dto;
using System;

namespace HamVarzeshi.Clubs.Dto
{
    public class PagedClubResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
