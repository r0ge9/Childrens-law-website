using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Diplom.Domain.Entities
{
	public  class Event
	{
		[Key]
		public int Id { get;set;}
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime Date { get; set; }
		[Required]
		public string Publisher { get; set; }
		[Required]
		public string Text { get; set; }
		
		public byte[] Image { get; set; }
	}
}
