using Microsoft.EntityFrameworkCore;
using Platenumbers.Application.Contracts.Persistance;
using PlateNumbers.Persistence.DatabaseContext;
using PlateNumbers.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Persistance.Repositories
{
    public class OrderNumberRepository : GenericRepository<OrderNumber>, IOrderNumberRepository
    {

        public OrderNumberRepository(PlateNumberContext context) : base(context)
        {
        }

        public async Task<int> CreateAsync(List<string> numbers)
        {
            var plateNumbers = await _context.plateNumbers.Where(q => numbers.Contains(q.Number)).ToListAsync();
            if (numbers.Count() != plateNumbers.Count())
                throw new Exception("ნომერი არ არსებობს");

            if (plateNumbers.Any(q => q.OrderNumberId != null))
                throw new Exception("ნომერი უკვე შეკვეთილია");

            var reservedNumber = new OrderNumber();
            reservedNumber.ExpireDate = DateTime.Now.AddDays(5);

            await _context.orderNumbers.AddAsync(reservedNumber);
            await _context.SaveChangesAsync();

            foreach (var item in plateNumbers)
            {
                item.OrderNumberId = reservedNumber.Id;
            }

            await _context.SaveChangesAsync();

            return reservedNumber.Id;
        }

        public async Task DeleteAsync(OrderNumber entity)
        {
            var orderNumber = _context.plateNumbers.Where(x => x.OrderNumberId == entity.Id);
            foreach (var item in orderNumber)
            {
                item.OrderNumber = null;
                item.OrderNumberId = null;
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
