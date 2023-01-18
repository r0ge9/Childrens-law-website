using Microsoft.Build.Framework;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Diplom.Domain.Entities
{
	public  class Test
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Type { get; set; }
		[Required]
		public string Question { get; set; }
		[Required]
		public string Answers { get; set; }

		[Required]
		public string RightAnswer { get; set; }

	}
}
