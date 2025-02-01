//====================================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//====================================================

using System.Threading.Tasks;
using Shenam.API.Brokers.Storages;
using Shenam.API.Models.Foundations.Guests;

namespace Shenam.API.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;

        public GuestService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Guest> InsertGuestAsync(Guest guest) =>
           await this.storageBroker.InsertGuestAsync(guest);
    }
}
