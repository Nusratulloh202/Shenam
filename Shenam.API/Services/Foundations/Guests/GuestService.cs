//====================================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//====================================================

using System;
using System.Threading.Tasks;
using Shenam.API.Brokers.Loggings;
using Shenam.API.Brokers.Storages;
using Shenam.API.Models.Foundations.Guests;
using Shenam.API.Models.Foundations.Guests.Exceptions;

namespace Shenam.API.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestService(IStorageBroker storageBroker,
                            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }


        public async ValueTask<Guest> InsertGuestAsync(Guest guest)
        {
            try
            {
                if (guest is null)
                {
                throw new NullGuestException();
                }

                return await this.storageBroker.InsertGuestAsync(guest);

            }
            catch (NullGuestException nullGuestException)
            {
                var guestValidationException =
                    new GuestValidationException(nullGuestException);
                loggingBroker.LogError(guestValidationException);


                throw guestValidationException;
            }
        }

    }
}
