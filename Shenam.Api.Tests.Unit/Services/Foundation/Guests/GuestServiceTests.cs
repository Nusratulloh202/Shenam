﻿//====================================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//====================================================
using System.Linq.Expressions;
using Moq;
using Xeptions;
using Shenam.API.Brokers.Loggings;
using Shenam.API.Brokers.Storages;
using Shenam.API.Models.Foundations.Guests;
using Shenam.API.Services.Foundations.Guests;
using Tynamix.ObjectFiller;

namespace Shenam.Api.Tests.Unit.Services.Foundation.Guests
{
    public partial class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IGuestService guestService;

        public GuestServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.guestService = 
                new GuestService(storageBroker: 
                this.storageBrokerMock.Object,
                this.loggingBrokerMock.Object);
        }
        private static Guest CreateRandomGuest() =>
           CreateGuestFiller(date:GetRandomDateTime()).Create();


        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private Expression<Func<Xeption,bool>> SameExceptionAs(Xeption expectedException)
        {
            return actualExeption=>
                actualExeption.Message == expectedException.Message
                && actualExeption.InnerException.Message == expectedException.InnerException.Message
                && (actualExeption.InnerException as Xeption).DataEquals(expectedException.InnerException.Data);

        }

        private static Filler<Guest>CreateGuestFiller(DateTimeOffset date)
        {
            var filler = new Filler<Guest>();;;
            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);
            return filler;
        }
    }
}
