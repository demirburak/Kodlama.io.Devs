using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ITechRepository : IAsyncRepository<Tech>, IRepository<Tech>
    {
    }
}
