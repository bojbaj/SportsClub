using System;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using HamVarzeshi.Authorization.Users;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.ClubSessionRegisters.Dto
{
    public class DeleteClubSessionRegisterDto
    {
        [Required]
        public Guid ClubSessionId { get; set; }
    }
}
