using Mabill.Domain.Enums;
using Mabill.Service.Dtos.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Mabill.Service.Helpers
{
    public class HttpContextHelper
    {
        private readonly IHttpContextAccessor contextAccessor;

        public HttpContextHelper(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public UserFromClaimsDto GetCurrentUser()
        {
            var userInfo = contextAccessor.HttpContext.User;
            UserFromClaimsDto user = new UserFromClaimsDto();

            user.Id = Guid.Parse(userInfo.FindFirst("Id").Value);
            user.Username = userInfo.FindFirst(ClaimTypes.NameIdentifier).Value;
            user.PhoneNumber = userInfo.FindFirst(ClaimTypes.MobilePhone).Value;
            Enum.TryParse(userInfo.FindFirst(ClaimTypes.Role).Value, out StaffRole role);
            user.Role = role;
            user.FirstName = userInfo.FindFirst("FirstName").Value;
            user.LastName = userInfo.FindFirst("LastName").Value;

            return user;
        }

    }
}
