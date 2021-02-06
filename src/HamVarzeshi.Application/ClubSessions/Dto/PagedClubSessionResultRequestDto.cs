using Abp.Application.Services.Dto;
using System;

namespace HamVarzeshi.ClubSessions.Dto
{
    public class PagedClubSessionResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
