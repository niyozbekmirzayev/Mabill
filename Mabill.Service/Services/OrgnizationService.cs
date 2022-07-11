using AutoMapper;
using Mabill.Data.IRepositories;
using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using Mabill.Domain.Entities.StaffsInOrganizations;
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
        private readonly ILoaneeBalanceInJournalRepository loaneeBalanceInJournalRepository;
        private readonly IStaffInOrganizationRepository staffInOrganizationRepository;
        private readonly HttpContextHelper httpContextHelper;

        public OrgnizationService(IOrganizationRepository IOrganizationRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository, IJournalRepository journalRepository,
            ILoanRepository loanRepository, ILoaneeBalanceInJournalRepository loaneeBalanceInJournalRepository,
            IStaffInOrganizationRepository staffInOrganizationRepository)
        {
            httpContextHelper = new HttpContextHelper(httpContextAccessor);
            organizationRepository = IOrganizationRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.journalRepository = journalRepository;
            this.loanRepository = loanRepository;
            this.loaneeBalanceInJournalRepository = loaneeBalanceInJournalRepository;
            this.staffInOrganizationRepository = staffInOrganizationRepository;
        }

        public async Task<BaseResponse<StaffInOrganization>> ChangeOwner(ChangeOrganizationOwnerDto changeOrganizationOwnerDto)
        {
            var response = new BaseResponse<StaffInOrganization>();

            var currentUser = httpContextHelper.GetCurrentUser();

            var owner = userRepository.GetAll(p => p.Id == currentUser.Id && p.Status != ObjectStatus.Deleted, false)
               .Include(user => user.Occupations.Where(o => o.Status != ObjectStatus.Deleted && o.OrganizationId == changeOrganizationOwnerDto.Id && o.Organization.Status != ObjectStatus.Deleted && o.Role == StaffRole.Owner && o.UserId == currentUser.Id))
                    .ThenInclude(o => o.Organization)
               .FirstOrDefault();

            #region Data validation
            if (owner == null)
            {
                response.Error = new BaseError(404, "User not found");

                return response;
            }

            if (owner.Occupations == null || !owner.Occupations.Any() || owner.Occupations.FirstOrDefault().Organization == null)
            {
                response.Error = new BaseError(400, $"User has no owner role in organization");

                return response;
            }

            if (owner.Id == changeOrganizationOwnerDto.NewOwnerId)
            {
                response.Error = new BaseError(400, $"New owner is the same as current owner");

                return response;
            }

            if (changeOrganizationOwnerDto.Password.EncodeInSha256() != owner.Occupations.FirstOrDefault().Organization.Password)
            {
                response.Error = new BaseError(400, "Invalid password");

                return response;
            }

            var newOwner = await userRepository.GetAsync(u => u.Id == changeOrganizationOwnerDto.NewOwnerId && u.Status != ObjectStatus.Deleted);
            if (newOwner == null)
            {
                response.Error = new BaseError(404, "New owner profile not found");

                return response;
            }
            #endregion

            owner.Occupations.FirstOrDefault(o => o.Status != ObjectStatus.Deleted && o.OrganizationId == changeOrganizationOwnerDto.Id && o.Organization.Status != ObjectStatus.Deleted && o.Role == StaffRole.Owner && o.UserId == currentUser.Id).Delete(owner.Id);
            var exOwnerOccupation = new StaffInOrganization(owner.Id, changeOrganizationOwnerDto.Id, StaffRole.ExOwner);
            exOwnerOccupation.Create(owner.Id);
            var createdExOwnerOccupation = await staffInOrganizationRepository.CreateAsync(exOwnerOccupation);
            owner.Occupations.Add(createdExOwnerOccupation);

            var exOwnerOccupationsInHistory = staffInOrganizationRepository.GetAll(o => o.UserId == changeOrganizationOwnerDto.NewOwnerId && o.Status != ObjectStatus.Deleted && o.Role == StaffRole.ExOwner, false).ToList();
            if (exOwnerOccupationsInHistory != null && exOwnerOccupationsInHistory.Any())
            {
                exOwnerOccupationsInHistory.ForEach(e => e.Delete(owner.Id));
            }

            var ownerOccupation = new StaffInOrganization(newOwner.Id, changeOrganizationOwnerDto.Id, StaffRole.Owner);
            ownerOccupation.Create(owner.Id);
            var createdOwnerOccupation = await staffInOrganizationRepository.CreateAsync(ownerOccupation);
            newOwner.Occupations.Add(createdOwnerOccupation);
            await organizationRepository.SaveChangesAsync();

            response.Data = await staffInOrganizationRepository.GetAsync(o => o.OrganizationId == changeOrganizationOwnerDto.Id && o.Role == StaffRole.Owner && o.Status != ObjectStatus.Deleted);

            return response;
        }

        public async Task<BaseResponse<Organization>> CreateAsync(CreateOrganizationDto createOrganizationDto)
        {
            var response = new BaseResponse<Organization>();

            #region Date validation
            if (createOrganizationDto == null)
            {
                response.Error = new BaseError(400, "Invalid data");

                return response;
            }

            var exsistOrganization = await organizationRepository.GetAsync(o => o.Status != ObjectStatus.Deleted &&
                                                                          o.Name.Trim().ToLower() == createOrganizationDto.Name.Trim().ToLower());

            if (exsistOrganization != null)
            {
                response.Error = new BaseError(409, "Name of this organization already exsists");

                return response;
            }
            #endregion

            var currentUser = httpContextHelper.GetCurrentUser();
            var owner = await userRepository.GetAsync(p => p.Id == currentUser.Id && p.Status != ObjectStatus.Deleted, false);
            if (owner == null)
            {
                response.Error = new BaseError(404, "User not found");

                return response;
            }

            createOrganizationDto.Password = createOrganizationDto.Password.EncodeInSha256();
            var mappedOrganization = mapper.Map<Organization>(createOrganizationDto);
            mappedOrganization.Create(currentUser.Id);
            var createdOrganization = await organizationRepository.CreateAsync(mappedOrganization);

            var staffInOrganization = new StaffInOrganization(owner.Id, createdOrganization.Id, StaffRole.Owner);
            staffInOrganization.Create(currentUser.Id);
            await staffInOrganizationRepository.CreateAsync(staffInOrganization);

            await organizationRepository.SaveChangesAsync();
            response.Data = createdOrganization;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(DeleteOrganizationDto deleteOrganizationDto)
        {
            var response = new BaseResponse<bool>();
            var currentUser = httpContextHelper.GetCurrentUser();

            var owner = userRepository.GetAll(p => p.Id == currentUser.Id && p.Status != ObjectStatus.Deleted, false)
                .Include(user => user.Occupations.Where(o => o.OrganizationId == deleteOrganizationDto.Id && o.Organization.Status != ObjectStatus.Deleted && o.Role == StaffRole.Owner && o.UserId == currentUser.Id))
                    .ThenInclude(o => o.Organization)
                    .ThenInclude(o => o.Journals.Where(j => j.Status != ObjectStatus.Deleted))
                    .ThenInclude(l => l.Loans).Where(p => p.Status != ObjectStatus.Deleted)

                .Include(user => user.Occupations.Where(o => o.OrganizationId == deleteOrganizationDto.Id && o.Organization.Status != ObjectStatus.Deleted && o.Role == StaffRole.Owner && o.UserId == currentUser.Id))
                    .ThenInclude(o => o.Organization)
                    .ThenInclude(o => o.Journals.Where(j => j.Status != ObjectStatus.Deleted))
                    .ThenInclude(l => l.Loanees).Where(p => p.Status != ObjectStatus.Deleted)
                .FirstOrDefault();

            #region Data validation
            if (owner == null)
            {
                response.Error = new BaseError(404, "User not found");

                return response;
            }

            if (!owner.Occupations.Any())
            {
                response.Error = new BaseError(400, $"User is not an owner of {deleteOrganizationDto.Id} organization");

                return response;
            }

            if (deleteOrganizationDto.Password.EncodeInSha256() != owner.Occupations.FirstOrDefault().Organization.Password)
            {
                response.Error = new BaseError(400, "Invalid password");

                return response;
            }
            #endregion

            owner.Occupations.FirstOrDefault().Organization.Journals.SelectMany(j => j.Loans).ToList().ForEach(l => l.Delete(owner.Id));
            owner.Occupations.FirstOrDefault().Organization.Journals.SelectMany(j => j.Loanees).ToList().ForEach(l => l.Delete(owner.Id));
            owner.Occupations.FirstOrDefault().Organization.Journals.ToList().ForEach(j => j.Delete(owner.Id));
            owner.Occupations.FirstOrDefault().Organization.Delete(owner.Id);

            await organizationRepository.SaveChangesAsync();
            response.Data = true;

            return response;
        }

        public BaseResponse<IEnumerable<Organization>> GetAll(Expression<Func<Organization, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Organization>>();

            var organizations = organizationRepository.GetAll(expression);
            response.Data = organizations;

            return response;
        }

        public async Task<BaseResponse<Organization>> GetAsync(Expression<Func<Organization, bool>> expression)
        {
            var response = new BaseResponse<Organization>();

            var organization = await organizationRepository.GetAll(expression).Include(o => o.Staffs).ThenInclude(s => s.User).FirstOrDefaultAsync();

            if (organization == null)
            {
                response.Error = new BaseError(404, "Organization not found");

                return response;
            }

            response.Data = organization;

            return response;
        }

        public async Task<BaseResponse<Organization>> UpdateAysnc(UpdateOrganizationDto updateOrganizationDto)
        {
            var response = new BaseResponse<Organization>();
            var currentUser = httpContextHelper.GetCurrentUser();

            var owner = await userRepository.GetAll(u => u.Id == currentUser.Id && u.Status != ObjectStatus.Deleted)
                .Include(u => u.Occupations.Where(o => o.Status != ObjectStatus.Deleted && o.OrganizationId == updateOrganizationDto.Id && o.Role == StaffRole.Owner && o.Organization.Status != ObjectStatus.Deleted))
                .ThenInclude(o => o.Organization)
                .FirstOrDefaultAsync();

            #region Data validation
            if (owner == null) 
            {
                response.Error = new BaseError(404, "User not found");
            }

            if (owner.Occupations == null && !owner.Occupations.Any() && owner.Occupations.FirstOrDefault().Organization == null) 
            {
                response.Error = new BaseError(400, $"User has no owner role in organization");

                return response;
            }

            if (!String.IsNullOrEmpty(updateOrganizationDto.NewName) && updateOrganizationDto.NewName != owner.Occupations.FirstOrDefault().Organization.Name)
            {
                var exsistOrganizationNames = organizationRepository.GetAll(o => o.Status != ObjectStatus.Deleted).Select(o => o.Name).ToList();

                if(exsistOrganizationNames.Any(e => e == updateOrganizationDto.NewName)) 
                {
                    response.Error = new BaseError(409, "New name of organization already exsists");

                    return response;
                }
            }
            #endregion

            var mappedOrganization = mapper.Map(updateOrganizationDto, owner.Occupations.FirstOrDefault().Organization);
            mappedOrganization.Modify(currentUser.Id);
            var updatedOrganization = await organizationRepository.UpdateAsync(mappedOrganization);
            response.Data = mappedOrganization;

            return response;

        }
    }
}
