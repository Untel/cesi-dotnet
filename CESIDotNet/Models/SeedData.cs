using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace CESICommerce.Models
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            //Récupérattion du contexte Base de données de mon application
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            // Execution permettant une migration de la base de données afin de pouvoir ajouter des données
            context.Database.Migrate();
            //Verification que nous n'avons pas de context avec des produits dejà initialisé
            if (!context.Products.Any())
            //if (true)
                {
                    //Construction de l'emsemble des produits avec la méthode AddRange du context
                    context.Products.AddRange(
                        //A l'intérieur j'enchaine les new Produit
                        new Product { Name = "lol", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "lal", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "lel", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "lil", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "lul", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "loul", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "laul", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "lerl", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "lodsqsdql", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "losdql", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "laaol", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "loaal", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "loazdl", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "aadlol", Description = "lel", Price = 41, Category = "hello" },
                        new Product { Name = "lozdal", Description = "lel", Price = 41, Category = "hello" }

                    );
                //Je sauvegarde le contexte Base de données
                context.SaveChanges();
            }
            //context.Products.AddRange(new Product { Name = "lol", Description = "lel", Price = 41, Category = "hello" });
            //context.SaveChanges();

        }
    }
}
