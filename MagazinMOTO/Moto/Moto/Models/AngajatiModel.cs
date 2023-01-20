using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Moto.Models
{
    public class AngajatiModel
    {
        [Key]
        [Required]
        public int id { get; set; }

        public string nume { get; set; }
        public string prenume { get; set; }
        public string functie { get; set; }
    }

    public class AngajatDbContext : DbContext
    {
        public DbSet<AngajatiModel> Employees { get; set; }
    }

    internal class AddEmployee
    {
        public static void SignUpUser(AngajatDbContext context, int Id, string Nume, string Prenume, string Functie)
        {
            AngajatiModel employee = new AngajatiModel()
            {
                id = Id,
                nume = Nume,
                prenume = Prenume,
                functie = Functie
            };

            context.Employees.Add(employee);
            context.SaveChanges();
        }
    }
}
