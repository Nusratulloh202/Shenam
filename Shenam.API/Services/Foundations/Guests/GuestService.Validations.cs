using Shenam.API.Models.Foundations.Guests;
using Shenam.API.Models.Foundations.Guests.Exceptions;

namespace Shenam.API.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private void ValidateGuestNotNull(Guest guest)
        {
            if (guest is null)
            {
                throw new NullGuestException();
            }
        }
    }
}
