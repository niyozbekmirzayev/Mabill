using Mabill.Domain.Enums;
using Mabill.Service.Dtos.Staffs;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Mabill.Service.Helpers
{
    public class HttpContextHelpers
    {
        private readonly IHttpContextAccessor contextAccessor;

        public HttpContextHelpers(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public StaffFromClaimsDto GetCurrentStaff()
        {
            var user = contextAccessor.HttpContext.User;
            StaffFromClaimsDto staff = new StaffFromClaimsDto();

            staff.Id = Guid.Parse(user.FindFirst("Id").Value);
            staff.Username = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            staff.Email = user.FindFirst(ClaimTypes.Email).Value;
            staff.PhoneNumber = user.FindFirst(ClaimTypes.MobilePhone).Value;
            Enum.TryParse(user.FindFirst(ClaimTypes.Role).Value, out StaffRole role);
            staff.Role = role;
            staff.FirstName = user.FindFirst("FirstName").Value;
            staff.LastName = user.FindFirst("LastName").Value;

            return staff;
        }

    }
}
