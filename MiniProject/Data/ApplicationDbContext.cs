using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniProject.Models;

namespace MiniProject.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
       
    }

    public DbSet<TypeClient> TypeClients { get; set; }

    public DbSet<Client> clients { get; set; }

    public DbSet<Commande> Commandes { get; set; }

    public DbSet<Article> Articles { get; set; }

    public DbSet<ArticleCommande> ArticleCommandes { get; set; }
}

