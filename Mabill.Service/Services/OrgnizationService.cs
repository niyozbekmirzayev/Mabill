using AutoMapper;
using Mabill.Data.IRepositories;
using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using Mabill.Domain.Enums;
using Mabill.Service.Dtos.Organizations;
using Mabill.Service.Extensions;
using Mabill.Service.Helpers;
using Mabill.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mabill.Service.Services
{
    public class OrgnizationService : IOrganizationService
    {
        private readonly IMapper mapper;
        private readonly IOrganizationRepository organizationRepository;
        private readonly IUserRepository userRepository;
        private readonly IJournalRepository journalRepository;
        private readonly ILoanRepository loanRepository;
        private readonly HttpContextHelper httpContextHelper;

        public OrgnizationService(IOrganizationRepository IOrganizationRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository, IJournalRepository journalRepository,
            ILoanRepository loanRepository)
        {
            httpContextHelper = new HttpContextHelper(httpContextAccessor);
            organizationRepository = IOrganizationRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.journalRepository = journalRepository;
            this.loanRepository = loanRepository;
        }

        public async Task<BaseResponse<Organization>> CreateAsync(CreateOrganizationDto createOrganizationDto)
        {
            var response = new BaseResponse<Organization>();

            #region Date validation
            if (createOrganizationDto == null)
            {
                response.Error = new BaseError(401, "Invalid data");

                return response;
            }

            var exsistOrganization = await organizationRepository.GetAsync(o => o.Status != ObjectStatus.Deleted &&
                                                                          o.Name == createOrganizationDto.Name);

            if (exsistOrganization != null)
            {
                response.Error = new BaseError(405, "Name of this organization already exsists");

                return response;
            }
            #endregion

            var currentUser = httpContextHelper.GetCurrentUser();
            var mappedOrganization = mapper.Map<Organization>(createOrganizationDto);

            var owner = await userRepository.GetAsync(p => p.Id == currentUser.Id);
            owner.Role = StaffRole.Owner;

            mappedOrganization.Create(currentUser.Id);
            var createdOrganization = await organizationRepository.CreateAsync(mappedOrganization);
            createdOrganization.Staffs.Add(owner);
            
            await organizationRepository.SaveChangesAsync();
            response.Data = createdOrganization;

            return response;
        }
        
        public async Task<BaseResponse<bool>> DeleteAsync(DeleteOrganizationDto organization)
        {
            var response = new BaseResponse<bool>();
            var currentUser = httpContextHelper.GetCurrentUser();

            /*var owner = userRepository.GetAll(p => p.Id == currentUser.Id && organization.Password.EncodeInSha256() == p.Password)
                .Include(user => user.Organization).ThenInclude(o => o.Journals.Where(j => j.Status != ObjectStatus.Deleted)).ThenInclude(l => l.Loans).Where(p => p.Status != ObjectStatus.Deleted)
                .Include(k => k.Organization).ThenInclude(o => o.Journals.Where(j => j.Status != ObjectStatus.Deleted)).ThenInclude(l => l.Loanees).Where(p => p.Status != ObjectStatus.Deleted)
                .FirstOrDefault();*/

            var owner = userRepository.GetAll().Include(p => p.Organization).First();
            
            if(owner == null) 
            {
                response.Error = new BaseError(401, "Invalid password");

                return response;
            }
            
            
            if (owner.Organization == null || owner.Role == null || owner.Role != StaffRole.Owner)
            {
                response.Error = new BaseError(401, "User has no organization");
                
                return response;
            }

            owner.Organization.Journals.SelectMany(j => j.Loans).ToList().ForEach(l => l.Status = ObjectStatus.Deleted);
            owner.Organization.Journals.SelectMany(j => j.Loanees).ToList().ForEach(l => l.Status = ObjectStatus.Deleted);
            owner.Organization.Journals.ToList().ForEach(j => j.Status = ObjectStatus.Deleted);
            owner.Organization.Status = ObjectStatus.Deleted;

            await organizationRepository.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public BaseResponse<IEnumerable<Organization>> GetAll(Expression<Func<Organization, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
       
        public async Task<BaseResponse<Organization>> GetAsync(Expression<Func<Organization, bool>> expression)
        {
            var response = new BaseResponse<Organization>();

            var organization = await organizationRepository.GetAsync(expression);

            if (organization == null)
            {
                response.Error = new BaseError(404, "Organization not found");

                return response;
            }

            return response;
        }

        public Task<BaseResponse<Organization>> UpdateAysnc(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
