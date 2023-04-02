using Microsoft.EntityFrameworkCore;
using Platenumbers.Application.Contracts.Persistance;
using PlateNumbers.Persistence.DatabaseContext;
using PlateNumbers.Persistence.Repositories;

namespace PlateNumbers.Persistance.Repositories
{
    public class ReserveNumberRepository : GenericRepository<ReserveNumber>, IReserveNumberRepository
    {
        public ReserveNumberRepository(PlateNumberContext context) : base(context)
        {
        }

        public async Task<bool> getReservedNumber(string number)
        {
            if (number == null)
                throw new ArgumentNullException(nameof(number));

            var reservedNumber = await _context.reserveNumbers.AnyAsync(q => q.Equals(number));

            return reservedNumber;
        }
    }
}
