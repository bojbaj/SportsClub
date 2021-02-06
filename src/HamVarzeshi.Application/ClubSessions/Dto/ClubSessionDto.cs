using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.ClubSessions.Dto
{
    [AutoMapFrom(typeof(ClubSession))]
    public class ClubSessionDto : AuditedEntityDto<Guid>
    {
        public virtual Club Club { get; protected set; }
        public virtual Guid ClubId { get; protected set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }
    }
}