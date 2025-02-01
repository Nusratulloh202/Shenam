using Xeptions;

namespace Shenam.API.Models.Foundations.Guests.Exceptions
{
    public class NullGuestException:Xeption
    {
        public NullGuestException() : 
            base("Guest is Null"){ }
    }
}
