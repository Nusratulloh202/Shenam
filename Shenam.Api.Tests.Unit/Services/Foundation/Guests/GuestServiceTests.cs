//====================================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//====================================================
using Moq;
using Shenam.API.Brokers.Storages;
using Shenam.API.Models.Foundations.Guests;
using Shenam.API.Services.Foundations.Guests;
using Tynamix.ObjectFiller;

namespace Shenam.Api.Tests.Unit.Services.Foundation.Guests
{
    public partial class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IGuestService guestService;

        public GuestServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.guestService = 
                new GuestService(storageBroker: this.storageBrokerMock.Object);
        }
        private static Guest CreateRandomGuest() =>
           CreateGuestFiller(date:GetRandomDateTime()).Create();


        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<Guest>CreateGuestFiller(DateTimeOffset date)
        {
            var filler = new Filler<Guest>();;;
            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);
            return filler;
        }









        //[Fact]
        //public async Task ShoulGuestAddAsync()
        //{
        //    //Arrange
        //    Guest randomGuest = new Guest
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Alibek",
        //        LastName = "Aliqulov",
        //        Address = "Bo'rijar MFY",
        //        DateOfBirth = new DateTimeOffset(),
        //        Gender = GenderType.Male,
        //        PhoneNumber = "+998976349202",
        //        Email = "Nusrat202@gamil.com"
        //    };
        //    this.storageBrokerMock.Setup(broker =>
        //    broker.InsertGuestAsync(randomGuest))
        //        .ReturnsAsync(randomGuest);
        //    //Act
        //    Guest actual = await this.guestService.InsertGuestAsync(randomGuest);

        //    //Assert
        //    actual.Should().BeEquivalentTo(randomGuest);
        //}
    }
}
