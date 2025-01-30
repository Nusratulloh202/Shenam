using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shenam.API.Models.Foundations.Guests;

namespace Shenam.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Guests { get; set; }

        public async ValueTask<Guest> InsertGuestAsync(Guest guest)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Guest> guestEntityEntry = 
                await broker.Guests.AddAsync(guest);

            await broker.SaveChangesAsync();

            return guestEntityEntry.Entity;

        }

        //All Read barcha malumotlarni o'qish
        public  IQueryable<Guest> SelectAllGuest()
        {
            return this.Guests;
        }

        //Id Read ID orqali malumotlarni ko'rish
        public async ValueTask<Guest> SelectGuestByIdAsync(Guid guestId)
        {
            return await this.Guests.FindAsync(guestId);
        }
        
        //Update Guest ma'lumotlarni yangilash
        public async ValueTask<Guest> UpdateGuestAsync(Guest guest)
        {
            using var broker = new StorageBroker(this.configuration);
            EntityEntry<Guest> guestEntityEntry =
                broker.Guests.Update(guest);
            await broker.SaveChangesAsync();
            return guestEntityEntry.Entity;
        }
        //Delete Guest Ma'lumotlarni o'chirish
        public async ValueTask<Guest> DeleteGuestAsync(Guest guest)
        {
            using var broker = new StorageBroker(this.configuration);
            EntityEntry<Guest> guestEntityEntry =
                broker.Guests.Remove(guest);
            await broker.SaveChangesAsync();
            return guestEntityEntry.Entity;
        }


    }
}
