using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Sample_0.ModelFirstSource;

namespace Sample_0.CodeFirstSource
{
    /// <summary>
    /// DbContext: определяет контекст данных, используемый для взаимодействия с базой данных.
    /// DbModelBuilder: сопоставляет классы на языке C# с сущностями в базе данных.
    /// DbSet/DbSet<TEntity>: представляет набор сущностей, хранящихся в базе данных
    /// </summary>
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext()
            : base("DbConnection")
        { }
    }
}
