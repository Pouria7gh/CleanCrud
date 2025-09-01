using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Presistence.DbContexts
{
    internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();

            options.UseSqlServer("Server=CHICKEN-WINGS\\NEWSQLSERVER;Database=CleanCrud;User Id=CleanLogin;Password=Clean.123;TrustServerCertificate=true;");

            return new ApplicationDbContext(options.Options);
        }
    }
}
