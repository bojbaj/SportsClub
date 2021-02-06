using System;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;

namespace HamVarzeshi.Core.Domain
{
    public class Club : AuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Rate { get; set; }
        public decimal CostPerHour { get; set; }
        public bool IsActive { get; set; }
    }
}