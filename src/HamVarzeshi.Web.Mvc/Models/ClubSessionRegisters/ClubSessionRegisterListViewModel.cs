using System.Collections.Generic;
using HamVarzeshi.Clubs.Dto;
using HamVarzeshi.ClubSessions.Dto;

namespace HamVarzeshi.Web.Models.ClubSessionRegisters
{
    public class ClubSessionRegisterListViewModel
    {
        public IReadOnlyList<ClubDto> Clubs { get; set; }
        public IReadOnlyList<ClubSessionDto> ClubSessions { get; set; }
    }
}