namespace Platenumbers.Application.Contracts.Persistance
{
    public interface IReserveNumberRepository : IGenericRepository<ReserveNumber>
    {
        Task<bool> getReservedNumber(string name);
    }
}
