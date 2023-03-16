using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Models
{
	public class Article
	{
		public int Id { get; set; }
		[Required]
		[DisplayName("Reference Article")]
		public string ReferenceArticle { get; set; }
		[Required]
		public string Prix { get; set; }

		public string? Image { get; set; }

		//navigation properties
		public ICollection<ArticleCommande> ArticleCommandes { get; set; }

		[NotMapped]
		public IFormFile ImageFile { get; set; }


    }
}

