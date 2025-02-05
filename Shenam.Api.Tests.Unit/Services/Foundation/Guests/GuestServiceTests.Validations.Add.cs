//====================================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//====================================================
using Moq;
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
<<<<<<< users/Nusratulloh202/Tests-guest-servise-validations
            await Assert.ThrowsAsync<GuestValidationException>(() =>
                addGuestTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedGuestValidationException))),
                    Times.Once);
            this.storageBrokerMock.Verify(broker =>
                broker.InsertGuestAsync(It.IsAny<Guest>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
=======

>>>>>>> main
        }
    }
}
