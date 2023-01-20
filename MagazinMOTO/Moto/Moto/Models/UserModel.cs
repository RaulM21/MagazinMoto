using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encryption;
using Moto;

namespace Moto.Models
{
    public class UserModel
    {
        [Key]
        [Required]
        public int id { get; set; }

        public string nume { get; set; }
        public string prenume { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class UtilizatorDbContext : DbContext
    {
        public DbSet<UserModel> Utilizatori { get; set; }
    }

    internal class Data
    {
        public void SignUpUser(UtilizatorDbContext context,int Id, string Nume, string Prenume, string Username, string Password)
        {

            TextWriterTraceListener LogInfo = new TextWriterTraceListener("C:\\Users\\Alex\\source\\repos\\Moto\\Moto\\Log.txt", "LogInfo");
            UserModel user = new UserModel()
            {
                id=Id,
                nume = Nume,
                prenume = Prenume,
                username = Username,
                password = Password
            };
            LogInfo.WriteLine("Utilizatorul " + user.username + " a fost adaugat");
            LogInfo.Flush();
            Trace.Close();
            Crypto c = new Crypto();
            user.password=c.Crypt(user.password);
            context.Utilizatori.Add(user);
            context.SaveChanges();
        }
    }
}