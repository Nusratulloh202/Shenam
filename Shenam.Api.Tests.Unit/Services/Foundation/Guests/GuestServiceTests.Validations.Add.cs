using Shenam.API.Models.Foundations.Guests;
using Shenam.API.Models.Foundations.Guests.Exceptions;

namespace Shenam.Api.Tests.Unit.Services.Foundation.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddWhenGuestIsNullAndLogItAsync()
        {
            //Given
            Guest nullGuest = null;
            var nullGuestException = new NullGuestException();

            var expectedGuestValidationException =
                new GuestValidationException(nullGuestException);
            //When
            ValueTask<Guest> addGuestTask =
                this.guestService.InsertGuestAsync(nullGuest);
            //Then
            await Assert.ThrowsAsync<GuestValidationException>(() =>
                addGuestTask.AsTask());
        }
    }
}
