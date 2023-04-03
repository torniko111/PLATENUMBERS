using Platenumbers.Application.Features.PlateNumber.Commands.DeleteReserveNumber;

namespace Platenumbers.Application.Contracts.Persistance
{
    public interface IReserveNumberRepository : IGenericRepository<ReserveNumber>
    {
        Task<int> CreateAsync(List<string> numbers);
        Task<bool> getReservedNumber(string name);
    }
}
