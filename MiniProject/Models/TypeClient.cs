using System;
using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models
{
	public class TypeClient
	{
        public int Id { get; set; }

        [Required]
		public string Libelle { get; set; }

		public ICollection<Client> Clients { get; set; }			
	}
}

