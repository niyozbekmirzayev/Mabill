using Mabill.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace Mabill.API.Helpers
{
    public class WebHelperFunctions : Controller
    {
        public IActionResult SentResultWithStatusCode(dynamic source) 
        {
            if (source.Error is not null)
            {
                source.Success = false;
                if (source.Error.Code == 404) return NotFound(source);
                else if (source.Error.Code == 400) return BadRequest(source);
                else if (source.Error.Code == 409) return Conflict(source);
            }

            source.Success = true;

            return Ok(source);
        }
    }
}
