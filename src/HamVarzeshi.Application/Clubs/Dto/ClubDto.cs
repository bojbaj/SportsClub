using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace HamVarzeshi.Clubs.Dto
{
    [AutoMapFrom(typeof(HamVarzeshi.Core.Domain.Club))]
    public class ClubDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Rate { get; set; }
        public decimal CostPerHour { get; set; }
        public bool IsActive { get; set; }
    }
}