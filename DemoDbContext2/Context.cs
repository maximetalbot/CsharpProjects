using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDbContext2
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context:DbContext
    {
        public DbSet<Personne> Personnes { get; set; }
    }
}
