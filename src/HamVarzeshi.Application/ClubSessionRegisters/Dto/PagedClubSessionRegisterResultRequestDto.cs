using Abp.Application.Services.Dto;
using System;

namespace HamVarzeshi.ClubSessionRegisters.Dto
{
    public class PagedClubSessionRegisterResultRequestDto : PagedResultRequestDto
    {
        public long UserId { get; set; }
    }
}
