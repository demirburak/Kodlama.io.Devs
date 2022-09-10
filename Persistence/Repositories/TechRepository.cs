using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class TechRepository : EfRepositoryBase<Tech, AppDbContext>, ITechRepository
    {
        public TechRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
