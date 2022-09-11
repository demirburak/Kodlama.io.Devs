using System.Reflection.Emit;

namespace Application.Features.UserProfiles.Dtos
{
    public class UserProfileGetListDto
    {
        public int Id { get; set; }

        public string GithubAddress { get; set; }

        public virtual string Email { get; set; }
    }
}
