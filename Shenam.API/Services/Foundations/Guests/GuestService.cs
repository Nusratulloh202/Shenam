//====================================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//====================================================

using System.Threading.Tasks;
using Shenam.API.Brokers.Loggings;
using Shenam.API.Brokers.Storages;
using Shenam.API.Models.Foundations.Guests;


namespace Shenam.API.Services.Foundations.Guests
{
    public partial class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestService(IStorageBroker storageBroker,
                            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        //Exception Noise Cancelation =>Xatoliklar shovqinini bartaraf etish
        public ValueTask<Guest> InsertGuestAsync(Guest guest) =>
        TryCatch(async () =>
        {
                ValidateGuestNotNull(guest);
                return await this.storageBroker.InsertGuestAsync(guest);
        });

    }
}
