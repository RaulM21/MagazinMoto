using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazaginMOTO
{
    public class UserModel
    {
        public int id { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    class UtilizatorDbContext : DbContext
    {
        public DbSet<UserModel> Utilizatori { get; set; }
    }
}
