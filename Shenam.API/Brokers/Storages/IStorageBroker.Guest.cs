using System;
using System.Linq;
using System.Threading.Tasks;
using Shenam.API.Models.Foundations.Guests;

namespace Shenam.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        //Insert
        ValueTask<Guest> InsertGuestAsync(Guest guest);
        //All Read
        IQueryable<Guest> SelectAllGuest();
        //Id Read
        ValueTask<Guest> SelectGuestByIdAsync(Guid guistId);
        //Update
        ValueTask<Guest> UpdateGuestAsync(Guest guest);
        //Delete
        ValueTask<Guest> DeleteGuestAsync(Guest guest);
    }
}
