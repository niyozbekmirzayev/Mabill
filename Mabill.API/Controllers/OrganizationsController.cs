﻿using Mabill.API.Helpers;
using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using Mabill.Service.Dtos.Organizations;
using Mabill.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mabill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationService organizationService;
        private WebHelperFunctions webHelperFunctions;
        public OrganizationsController(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
            webHelperFunctions = new WebHelperFunctions();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateOrganizationDto organization)
        {
            Console.WriteLine("---> Creating organization....");
            var result = await organizationService.CreateAsync(organization);
            return webHelperFunctions.SentResultWithStatusCode(result);

           /* // Identification of error 
            if (result.Error is not null)
            {
                if (result.Error.Code == 404) return NotFound(result);
                else if (result.Error.Code == 400) return BadRequest(result);
                else if (result.Error.Code == 409) return Conflict(result);
            }

            return Ok(result);*/
        }

       /* [HttpGet]
        public async Task<ActionResult<BaseResponse<Organization>>> Get(string organizationName)
        {
            Console.WriteLine("---> Getting organization....");
            var result = await organizationService.GetAsync(o => o.Name.Trim().ToLower() == organizationName.Trim().ToLower());

            // Identification of error 
            if (result.Error is not null)
            {
                if (result.Error.Code == 404) return NotFound(result);
                else if (result.Error.Code == 400) return BadRequest(result);
                else if (result.Error.Code == 409) return Conflict(result);
            }

            return Ok(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<BaseResponse<Organization>>> Delete(DeleteOrganizationDto deleteOrganizationDto)
        {
            Console.WriteLine("---> Deleting organization....");
            var result = await organizationService.DeleteAsync(deleteOrganizationDto);

            // Identification of error 
            if (result.Error is not null)
            {
                if (result.Error.Code == 404) return NotFound(result);
                else if (result.Error.Code == 400) return BadRequest(result);
                else if (result.Error.Code == 409) return Conflict(result);
            }

            return Ok(result);
        }*/
    }
}

