using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entities;

namespace Data.Repositories
{
    public interface IUserRepository : IRepository<Customer>
    {
        Task<Customer> GetByUserAndPass(string username, string password, CancellationToken cancellationToken);

        Task AddAsync(Customer user, string password, CancellationToken cancellationToken);
        Task UpdateSecuirtyStampAsync(Customer user, CancellationToken cancellationToken);
        Task UpdateLastLoginDateAsync(Customer user, CancellationToken cancellationToken);
    }
}