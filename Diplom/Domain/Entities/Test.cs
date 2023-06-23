using Microsoft.Build.Framework;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Diplom.Domain.Entities
{
	public  class Test//сущность теста
	{
		[Key]//атрибуи первичного ключа
		public int Id { get; set; }
		[Required]//атрибут для обязательного ввода
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public string Image { get; set; }
		[ForeignKey("TestId")]//атрибут внешнего ключа
		
		public List<Question> Questions { get; set; }

	}
}
