using System.Threading.Tasks;
using Shenam.API.Models.Foundations.Guests;

namespace Shenam.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Guest> InsertGuestAsync(Guest guest);
    }
}
