using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Diplom.Domain.Entities
{
	public  class Event//сущность новости
	{
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "NameRequired")]//атрибут для проверки на заполненное поле
        [StringLength(50, ErrorMessage = "NameLength")]//атрибут для проверки на длину значения
        [Display(Name = "Name")]//атрибут для отображения текста "Название"
        public string Name { get; set; }
        [Required(ErrorMessage = "DateRequired")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "PublisherRequired")]
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }
        [Required(ErrorMessage = "TextRequired")]
        [StringLength(1000, ErrorMessage = "TextLength", MinimumLength = 50)]
        [Display(Name = "Text")]
        public string Text { get; set; }

        
        public string Image { get; set; }
    }
}
