using Microsoft.Build.Framework;

namespace Diplom.Domain.Entities
{
	public abstract class Event
	{
		[Required]
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
