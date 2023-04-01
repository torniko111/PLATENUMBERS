using Platenumbers.Domain;

namespace Platenumbers.Application.Contracts.Persistance
{
    public interface IPlateNumberRepository : IGenericRepository<PlateNumber>
    {
        Task<bool> IsPlateNumberUnique(string number);
    }
}
