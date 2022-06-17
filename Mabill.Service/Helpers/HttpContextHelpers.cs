using Mabill.Domain.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mabill.Service.Helpers
{
    public class HttpContextHelpers<T> where T: Person
    {
        private readonly IHttpContextAccessor contextAccessor;

        public HttpContextHelpers(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

       /* public T GetCurrentUser() 
        {
            contextAccessor.HttpContext.User.FindFirst(ClaimTypes.)
        }*/
        
    }
}
