using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Infrastructure.Data
{
    internal class LibrarySystemContextFactory: IDesignTimeDbContextFactory<LibrarySystemContext>
    {
        public LibrarySystemContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:\\Users\\Risyad Kamarullah\\source\\repos\\Assignment7\\Assignment7.WebAPI\\appsettings.json")
                .Build();

            var services = new ServiceCollection();

            services.ConfigureInfrastructure(configuration);

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider.GetRequiredService<LibrarySystemContext>();
        }
    }
}
