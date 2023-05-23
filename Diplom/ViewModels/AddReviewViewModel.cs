using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Diplom.ViewModels
{
    public class AddReviewViewModel
    {


        [Required(ErrorMessage ="NameRequired")]
        public string Name { get; set; }

        [Required(ErrorMessage ="SexRequired")]
        public string Sex { get; set; }

        [Required(ErrorMessage ="TextRequired")]
        [StringLength(1000, ErrorMessage = "TextLength", MinimumLength = 10)]
        public string Text { get; set; }
        [Required(ErrorMessage = "ImageRequired")]
        public string Image { get; set; }
    }
}
