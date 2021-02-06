using System.ComponentModel.DataAnnotations;

namespace HamVarzeshi.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}