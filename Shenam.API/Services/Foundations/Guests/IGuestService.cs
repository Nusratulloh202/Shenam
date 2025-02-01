//====================================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//====================================================

using System.Threading.Tasks;
using Shenam.API.Models.Foundations.Guests;

namespace Shenam.API.Services.Foundations.Guests
{
    public interface IGuestService
    {
        ValueTask<Guest> InsertGuestAsync(Guest guest);
    }
}
