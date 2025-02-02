using Xeptions;

namespace Shenam.API.Models.Foundations.Guests.Exceptions
{
    public class GuestValidationException: Xeption
    {
        public GuestValidationException(Xeption innerExeption)
            : base(message:"Guest validation error occured, fix the errors and try again.",
                  innerExeption)
        {         
        }
    }
}
