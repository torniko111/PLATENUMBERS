using Microsoft.EntityFrameworkCore;
using Platenumbers.Application.Contracts.Persistance;
using PlateNumbers.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Persistance.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlateNumberContext _plateNumberContext;
     
        public IPlateNumberRepository Numbers {get; }

        public IReserveNumberRepository Reserves { get; }

        public IOrderNumberRepository Orders { get; }

        public UnitOfWork(PlateNumberContext plateNumberContext, 
            IPlateNumberRepository plateNumberRepository,
            IReserveNumberRepository reserveNumberRepository, 
            IOrderNumberRepository orderNumberRepository)
        {
            this._plateNumberContext = plateNumberContext;
            this.Numbers = plateNumberRepository;
            this.Reserves = reserveNumberRepository;
            this.Orders = orderNumberRepository;
        }

        public int Complete()
        {
            return _plateNumberContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _plateNumberContext.Dispose();
            }
        }
    }
}
