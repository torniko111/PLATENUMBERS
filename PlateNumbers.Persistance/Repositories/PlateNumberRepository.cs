using Microsoft.EntityFrameworkCore;
using Platenumbers.Application.Contracts.Persistance;
using Platenumbers.Domain;
using PlateNumbers.Persistence.DatabaseContext;
using PlateNumbers.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlateNumbers.Persistance.Repositories
{
    public class PlateNumberRepository : GenericRepository<PlateNumber>, IPlateNumberRepository
    {
        public PlateNumberRepository(PlateNumberContext context) : base(context)
        {
        }

        public async Task<bool> IsPlateNumberUnique(string number)
        {
            return await _context.plateNumbers.AnyAsync(q => q.Number == number) == false;
        }

        public override async Task DeleteAsync(PlateNumber entity)
        {
            var toDelete =  _context.plateNumbers.FirstOrDefault(q => q.Number == entity.Number);

            if (toDelete == null)
                throw new Exception("ასეთი ნომერი არ არსებობს");

            if (toDelete.ReserveNumberId != null)
            {
                throw new Exception("ნომერი დაჯავშნილია, მისი წაშლა შეუძლებელია");
            }
            if (toDelete.OrderNumberId != null)
            {
                throw new Exception("ნომერი შეკვეთილია, მისი წაშლა შეუძლებელია");
            }


            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }


        public override async Task UpdateAsync(PlateNumber entity)
        {
            var toUp = _context.plateNumbers.FirstOrDefault(x => x.Id == entity.Id);
            if (toUp == null)
                throw new Exception("ასეთი ნომერი არ არსებობს");

            if (toUp.ReserveNumberId != null)
            {
                throw new Exception("ნომერი დაჯავშნილია, მისი შეცვლა შეუძლებელია");
            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<PlateNumber>> PaginationOrdering(int Count, int NumberOfpage)
        {

            if (Count != null && NumberOfpage !=null)
            {
                int NumberPerpage = 0;
                int Page = 0;
             

                return await _context.Set<PlateNumber>().Skip(Count* NumberOfpage).Take(Count).ToListAsync();
            }

            return await _context.Set<PlateNumber>().ToListAsync();
        }
    }
}
