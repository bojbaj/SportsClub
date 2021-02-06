using System;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;

namespace HamVarzeshi.Core.Domain
{
    public class ClubSessionRegister : AuditedEntity<Guid>
    {
        public ClubSession ClubSession { get; protected set; }
        public Guid ClubSessionId { get; protected set; }
        public long RegisteredUserId { get; set; }        
        public decimal TotalCosts { get; set; }        
    }
}