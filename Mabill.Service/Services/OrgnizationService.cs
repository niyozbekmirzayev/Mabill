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

       /* public async Task<BaseResponse<bool>> ChangeOwner(ChangeOrganizationOwnerDto changeOrganizationOwnerDto)
        {
            var response = new BaseResponse<bool>();

            var currentUser = httpContextHelper.GetCurrentUser();

            var owner = await userRepository.GetAll(p => p.Id == currentUser.Id && p.Status != ObjectStatus.Deleted, false).Include(o => o.Organization).FirstOrDefaultAsync();

            #region Data validation
            if (owner == null)
            {
                response.Error = new BaseError(401, "User not found");

                return response;
            }

            if (owner.Organization == null || owner.Organization.Status == ObjectStatus.Deleted || owner.Role == null || owner.Role != StaffRole.Owner)
            {
                response.Error = new BaseError(401, "User has no organization");

                return response;
            }

            if (changeOrganizationOwnerDto.OrganizationPassword.EncodeInSha256() != owner.Organization.Password.EncodeInSha256())
            {
                response.Error = new BaseError(401, "Invalid password");

                return response;
            }

            var newOwner = await userRepository.GetAsync(u => u.Id == changeOrganizationOwnerDto.NewOwnerId && u.Status != ObjectStatus.Deleted);
            if (newOwner == null)
            {
                response.Error = new BaseError(401, "User not found");

                return response;
            }

            if (newOwner.Role! || newOwner.Organization.Status == ObjectStatus.Deleted)
            {
                response.Error = new BaseError(401, "User has no organization");

                return response;
            }
            #endregion
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
                                                                          o.Name.Trim().ToLower() == createOrganizationDto.Name.Trim().ToLower());

            if (exsistOrganization != null)
            {
                response.Error = new BaseError(405, "Name of this organization already exsists");

                return response;
            }
            #endregion

            var currentUser = httpContextHelper.GetCurrentUser();
            createOrganizationDto.Password = createOrganizationDto.Password.EncodeInSha256();
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

        public async Task<BaseResponse<bool>> DeleteAsync(DeleteOrganizationDto deleteOrganizationDto)
        {
            var response = new BaseResponse<bool>();
            var currentUser = httpContextHelper.GetCurrentUser();

            var owner = userRepository.GetAll(p => p.Id == currentUser.Id && p.Status != ObjectStatus.Deleted, false)
                .Include(user => user.Organization).ThenInclude(o => o.Journals.Where(j => j.Status != ObjectStatus.Deleted)).ThenInclude(l => l.Loans).Where(p => p.Status != ObjectStatus.Deleted)
                .Include(k => k.Organization).ThenInclude(o => o.Journals.Where(j => j.Status != ObjectStatus.Deleted)).ThenInclude(l => l.Loanees).Where(p => p.Status != ObjectStatus.Deleted)
                .AsSplitQuery()
                .FirstOrDefault();

            #region Data validation
            if (owner == null)
            {
                response.Error = new BaseError(401, "User not found");

                return response;
            }

            if (owner.Organization == null || owner.Organization.Status == ObjectStatus.Deleted || owner.Role == null || owner.Role != StaffRole.Owner)
            {
                response.Error = new BaseError(401, "User has no organization");

                return response;
            }

            if (deleteOrganizationDto.OrganizationPassword.EncodeInSha256() != owner.Organization.Password.EncodeInSha256())
            {
                response.Error = new BaseError(401, "Invalid password");

                return response;
            }
            #endregion

            owner.Organization.Journals.SelectMany(j => j.Loans).ToList().ForEach(l => l.Delete(owner.Id));
            owner.Organization.Journals.SelectMany(j => j.Loanees).ToList().ForEach(l => l.Delete(owner.Id));
            owner.Organization.Journals.ToList().ForEach(j => j.Delete(owner.Id));
            owner.Organization.Delete(owner.Id);

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

        public Task<BaseResponse<Organization>> UpdateAysnc(Organization updateOrganizationDto)
        {
            throw new NotImplementedException();
        }*/
    }
}
