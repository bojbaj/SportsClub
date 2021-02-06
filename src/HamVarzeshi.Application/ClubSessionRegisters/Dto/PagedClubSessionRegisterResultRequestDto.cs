using Abp.Application.Services.Dto;
using System;

namespace HamVarzeshi.ClubSessionRegisters.Dto
{
    public class PagedClubSessionRegisterResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public long UserId { get; set; }
    }
}
