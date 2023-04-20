using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
	public class EditEventViewModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage ="NameRequired")]
		[StringLength(50,ErrorMessage ="NameLength")]
		[Display(Name="Name")]
		public string Name { get; set; }
		[Required(ErrorMessage ="DateRequired")]
		[Display(Name = "Date")]	
		public DateTime Date { get; set; }
		[Required(ErrorMessage ="PublisherRequired")]
		[Display(Name = "Publisher")]
		public string Publisher { get; set; }
		[Required(ErrorMessage ="TextRequired")]
		[StringLength(1000,ErrorMessage ="TextLength",MinimumLength =50)]
		[Display(Name="Text")]
		public string Text { get; set; }
		[Display(Name="Image")]
		public string Image { get; set; }
	}
}
