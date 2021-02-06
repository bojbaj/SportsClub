using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.ClubSessionRegisters.Dto
{
    [AutoMapFrom(typeof(ClubSessionRegister))]
    public class ClubSessionRegisterDto : AuditedEntityDto<Guid>
    {
        public ClubSession ClubSession { get; set; }
        public Guid ClubSessionId { get; set; }
        public long RegisteredUserId { get; set; }
        public decimal TotalCosts
        {
            get
            {
                if (ClubSession?.Club == null)
                    return 0;
                return ClubSession.Club.CostPerHour * ClubSession.Duration;
            }
        }    
    }
}