using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using HamVarzeshi.Authorization.Users;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.Clubs.Dto
{
    [AutoMapTo(typeof(Club))]
    public class CreateClubDto
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public decimal CostPerHour { get; set; }

        [Required]
        public decimal Rate { get; set; }

        public bool IsActive { get; set; }
    }
}
