﻿using Microsoft.AspNetCore.Cors;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Diplom.Domain.Entities
{
	public  class Review
	{
		[Key]
		public int Id { get; set; }

		[Display(Name ="FullName"),Required]
		public string Name { get; set; }

		[Required]
		public string Sex { get; set; }

		[Required]
		public string Text { get; set; }
		public string Image { get; set; }
	}
}
