using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataProviders.SqlServer
{
    public class SqlSerDbContext : EfDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) => optionBuilder.UseSqlServer(@"Data Source=DBSRV\MSSQL2021;Initial Catalog=LessonManagerDY;Integrated Security=True");
    }
}
