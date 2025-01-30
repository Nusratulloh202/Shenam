using System.Linq;
using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shenam.API.Models.Foundations.Guests;

namespace Shenam.API.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = 
                 this.configuration.GetConnectionString(name: "DefaultConnection");

            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public override void Dispose(){

    }
}
