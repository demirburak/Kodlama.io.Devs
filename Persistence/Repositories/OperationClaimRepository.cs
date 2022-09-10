using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, AppDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
