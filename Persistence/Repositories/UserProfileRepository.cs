using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserProfileRepository : EfRepositoryBase<UserProfile, AppDbContext>, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
