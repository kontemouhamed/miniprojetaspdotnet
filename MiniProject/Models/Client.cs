using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models
{
	public class Client
	{
		public int Id { get; set; }

		[Required]
		[DisplayName("Numéro client")]
		public string NumeroCLient { get; set; }

		[Required]
		public string Nom { get; set; }

		[Required]
		public string Prenom { get; set; }

		[Required]
		public string Adresse { get; set; }

		// Navigation properties
		public TypeClient TypeClient { get; set; }

		public ICollection<Commande> Commandes { get; set; }

	}
}

