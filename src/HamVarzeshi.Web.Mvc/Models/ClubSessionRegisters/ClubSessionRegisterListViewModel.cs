using System.Collections.Generic;
using System.Linq;
using HamVarzeshi.Clubs.Dto;
using HamVarzeshi.ClubSessionRegisters.Dto;
using HamVarzeshi.ClubSessions.Dto;

namespace HamVarzeshi.Web.Models.ClubSessionRegisters
{
    public class ClubSessionRegisterListViewModel
    {
        public IReadOnlyList<ClubDto> Clubs { get; set; }
        public IReadOnlyList<ClubSessionDto> ClubSessions { get; set; }
        public IReadOnlyList<ClubSessionRegisterDto> ClubSessionRegisters { get; set; }
        public bool IsRegistered(ClubSessionDto clubSession)
        {
            return ClubSessionRegisters.Any(x => x.ClubSessionId.Equals(clubSession.Id));
        }
    }
}