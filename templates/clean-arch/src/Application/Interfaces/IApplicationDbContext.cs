using System.Threading;
using System.Threading.Tasks;
using [solutionName].Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace [solutionName].Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
