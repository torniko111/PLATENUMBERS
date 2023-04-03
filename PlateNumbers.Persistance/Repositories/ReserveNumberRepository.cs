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

        public async Task<int> CreateAsync(List<string> numbers)
        {
            var plateNumbers = await _context.plateNumbers.Where(q => numbers.Contains(q.Number)).ToListAsync();
            if (numbers.Count() !=  plateNumbers.Count())
                throw new Exception("ნომერი არ არსებობს");

            if(plateNumbers.Any(q=>q.ReserveNumberId != null))
                throw new Exception("ნომერი უკვე დაჯავშნილია");

            var reservedNumber = new ReserveNumber();
            reservedNumber.ExpireDate = DateTime.Now.AddDays(5);
            



            await _context.reserveNumbers.AddAsync(reservedNumber);
            await _context.SaveChangesAsync();

            foreach (var item in plateNumbers)
            {
                item.ReserveNumberId = reservedNumber.Id;
            }

            await _context.SaveChangesAsync();

            return reservedNumber.Id;   
        }
    }
}
