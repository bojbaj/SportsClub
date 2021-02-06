using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.ClubSessions.Dto
{
    [AutoMapFrom(typeof(ClubSession))]
    public class ClubSessionDto : AuditedEntityDto<Guid>
    {
        public virtual Club Club { get; set; }
        public virtual Guid ClubId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }
        public decimal TotalCosts
        {
            get
            {
                if (Club == null)
                    return 0;
                return Club.CostPerHour * Duration;
            }
        }
    }
}