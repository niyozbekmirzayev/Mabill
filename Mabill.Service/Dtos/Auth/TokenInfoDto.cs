using System;

namespace Mabill.Service.Dtos.Auth
{
    public class TokenInfoDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
