using Platenumbers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Contracts.Persistance
{
    public interface IOrderNumberRepository : IGenericRepository<OrderNumber>
    {
        Task<int> CreateAsync(List<string> numbers);
    }
}
