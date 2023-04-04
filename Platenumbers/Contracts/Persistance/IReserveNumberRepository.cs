using Platenumbers.Application.Features.ReserveNumber.Commands.DeleteReserveNumber;

namespace Platenumbers.Application.Contracts.Persistance
{
    public interface IReserveNumberRepository : IGenericRepository<ReserveNumber>
    {
        Task<int> CreateAsync(List<string> numbers);
        Task<bool> getReservedNumber(string name);
    }
}
