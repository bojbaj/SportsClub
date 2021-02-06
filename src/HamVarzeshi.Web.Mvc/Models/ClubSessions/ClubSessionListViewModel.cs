using System.Collections.Generic;
using HamVarzeshi.Clubs.Dto;

namespace HamVarzeshi.Web.Models.ClubSessions
{
    public class ClubSessionListViewModel
    {
        public IReadOnlyList<ClubDto> Clubs { get; set; }        
    }
}