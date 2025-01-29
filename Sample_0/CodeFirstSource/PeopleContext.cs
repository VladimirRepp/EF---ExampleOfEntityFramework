using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_0.CodeFirstSource
{
    public class PeopleContext : DbContext
    {
        public DbSet<People> Peoples { get; set; }

        public PeopleContext()
            : base("DbConnection")
        { }
    }
}
