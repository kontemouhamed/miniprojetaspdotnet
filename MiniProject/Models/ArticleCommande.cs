using System;
namespace MiniProject.Models
{
	public class ArticleCommande
	{
		public int Id { get; set;}

		// navigation properties
		public Commande Commande { get; set; }
		public Article Article { get; set; }
	}
}

