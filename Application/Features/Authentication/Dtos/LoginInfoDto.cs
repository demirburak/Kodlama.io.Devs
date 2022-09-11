using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Dtos
{
    public class LoginResultDto
    {
        public bool IsSuccess { get; set; }

        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public LoginResultDto()
        {
            IsSuccess = false;
        }

        public LoginResultDto(bool ısSuccess, string token, DateTime expiration) : this()
        {
            IsSuccess = ısSuccess;
            Token = token;
            Expiration = expiration;
        }
    }
}
