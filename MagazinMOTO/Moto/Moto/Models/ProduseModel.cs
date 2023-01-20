using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Moto.Models
{
    public class ProduseModel
    {
        [Key]
        [Required]
        public int id { get; set; }

        public string nume { get; set; }
        public string descriere { get; set; }
        public string cantitate { get; set; }
        public string producator { get; set; }
    }

    public class ProdusDbContext : DbContext
    {
        public DbSet<ProduseModel> Produse { get; set; }
    }

    internal class ProdData
    {
        public static void SignUpUser(ProdusDbContext context, int Id, string Nume, string Descriere, string Cantitate, string Producator)
        {
            ProduseModel produs = new ProduseModel()
            {
                id = Id,
                nume = Nume,
                descriere = Descriere,
                cantitate = Cantitate,
                producator = Producator
            };

            context.Produse.Add(produs);
            context.SaveChanges();
        }
    }
}
