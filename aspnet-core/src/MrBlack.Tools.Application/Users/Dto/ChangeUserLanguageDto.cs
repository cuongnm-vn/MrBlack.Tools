using System.ComponentModel.DataAnnotations;

namespace MrBlack.Tools.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}