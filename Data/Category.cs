﻿using System.ComponentModel.DataAnnotations;

namespace BlogProject.Data
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		public string Name { get; set; }
	}
}
