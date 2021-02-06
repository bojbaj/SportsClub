using System;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using HamVarzeshi.Authorization.Users;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.ClubSessions.Dto
{
    [AutoMapTo(typeof(ClubSession))]
    public class CreateClubSessionDto
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        public Guid ClubId { get; protected set; }

        [Required]
        public int Duration { get; set; }
        public bool IsActive { get; set; }
    }
}
