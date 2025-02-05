//====================================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//====================================================

using System.Threading.Tasks;
using Shenam.API.Models.Foundations.Guests;
using Shenam.API.Models.Foundations.Guests.Exceptions;
using Xeptions; 

namespace Shenam.API.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private delegate ValueTask<Guest> ReturningGuestFunction();

        private async ValueTask<Guest> TryCatch(ReturningGuestFunction returningGuestFunction)
        {
            try
            {
                return await returningGuestFunction();
            }
            catch (NullGuestException nullGuestException)
            {
                throw CreatAndLogValidationException(nullGuestException);
            }
        }
        private GuestValidationException CreatAndLogValidationException(Xeption exception)
        {
            var guestValidationException =
                new GuestValidationException(exception);

            loggingBroker.LogError(guestValidationException);

            return guestValidationException;
        }
    }
}
