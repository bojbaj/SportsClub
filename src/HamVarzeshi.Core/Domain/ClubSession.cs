using System;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;

namespace HamVarzeshi.Core.Domain
{
    public class ClubSession : AuditedEntity<Guid>
    {
        public virtual Club Club { get; protected set; }
        public virtual Guid ClubId { get; protected set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }
    }
}