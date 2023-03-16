using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models
{
	public class Commande
	{
		public int Id { get; set; }

		[Required]
		[DisplayName("Numéro de commande")]
		public string NumeroCommande { get; set; }
        [Required]
        [DisplayName("Total Hors taxe")]
        public string TotalHt { get; set; }

        [Required]
        [DisplayName("Total TTC")]
        public string  TotalTtc{ get; set; }

        [Required]
        [DisplayName("Date de commande")]
        public DateTime DateCommande { get; set; }

        // navigation properties
        public Client Client { get; set; }

        public ICollection<ArticleCommande> ArticleCommandes { get; set; }
    }
}

