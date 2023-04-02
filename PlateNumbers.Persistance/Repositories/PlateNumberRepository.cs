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
    }
}
