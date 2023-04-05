using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Contracts.Persistance
{
    public interface IUnitOfWork : IDisposable
    {
        IPlateNumberRepository Numbers { get; }
        IReserveNumberRepository Reserves { get; }
        IOrderNumberRepository Orders { get; }

        int Complete();
    }
}
