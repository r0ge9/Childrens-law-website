using Microsoft.Build.Framework;
using Newtonsoft.Json;

namespace Diplom.Domain.Entities
{
	public abstract class Test
	{
		[Required]
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
