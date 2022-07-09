using Mabill.Data.IRepositories;
using Mabill.Data.Repositories;
using Mabill.Service.Interfaces;
using Mabill.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Mabill.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IOrganizationService, OrgnizationService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IJournalRepository, JournalRepository>();

            services.AddScoped<ILoanRepository, LoanRepository>();

            services.AddScoped<ILoaneeRepository, LoaneeRepository>();

            services.AddScoped<IStaffInOrganizationRepository, StaffInOrganizationRepository>();

            services.AddScoped<ILoaneeBalanceInJournalRepository, LoaneeBalanceInJournalRepository>();
        }
    }
}
