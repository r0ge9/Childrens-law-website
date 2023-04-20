using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Diplom.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="EmailRequired")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="PasswordRequired")]
        public string Password { get; set; }
        
    }
}
