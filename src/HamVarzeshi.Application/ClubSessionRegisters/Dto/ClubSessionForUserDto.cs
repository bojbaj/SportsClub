using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.ClubSessions.Dto
{
    [AutoMapFrom(typeof(ClubSession))]
    public class ClubSessionForUserDto : ClubSessionDto
    {
        public bool Registered { get; set; }
    }
}