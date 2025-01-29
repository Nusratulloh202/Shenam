using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shenam.API.Models.Foundations.Guests;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Shenam.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Guests { get; set; }

        public async ValueTask<Guest> InsertGuestAEntrysync(Guest guest)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Guest> guestEntitEntry = 
                await broker.Guests.AddAsync(guest);

            await broker.SaveChangesAsync();

            return guestEntitEntry.Entity;
        }
    }
}
