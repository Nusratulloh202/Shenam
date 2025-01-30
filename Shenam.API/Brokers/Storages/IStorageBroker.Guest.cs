using System;
using System.Linq;
using System.Threading.Tasks;
using Shenam.API.Models.Foundations.Guests;

namespace Shenam.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Guest> InsertGuestAsync(Guest guest);
        IQueryable<Guest> SelectAllGuest();
        ValueTask<Guest> SelectGuestByIdAsync(Guid guistId);
        ValueTask<Guest> UpdateGuestAsync(Guest guest);
        ValueTask<Guest> DeleteGuestAsync(Guest guest);
    }
}
