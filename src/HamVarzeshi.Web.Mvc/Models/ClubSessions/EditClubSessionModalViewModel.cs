using System.Collections.Generic;
using System.Linq;
using HamVarzeshi.Clubs.Dto;
using HamVarzeshi.ClubSessions.Dto;

namespace HamVarzeshi.Web.Models.ClubSessions
{
    public class EditClubSessionModalViewModel
    {
        public ClubSessionDto ClubSession { get; set; }
        public IReadOnlyList<ClubDto> Clubs { get; set; }
        public bool IsInClub(ClubDto club)
        {
            return ClubSession.ClubId.Equals(club.Id);
        }
    }
}
