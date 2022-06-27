using Mabill.Domain.Base;
using Mabill.Domain.Entities.Users;
using Mabill.Service.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mabill.Service.Interfaces
{
    public interface IUserService
    {
        BaseResponse<IEnumerable<User>> GetAll(Expression<Func<User, bool>> expression = null);
        Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression);
        Task<BaseResponse<User>> CreateAsync(CreateUserDto user);
        Task<BaseResponse<User>> UpdateProfileAsync(UpdateUserProfileDto user);
        Task<BaseResponse<bool>> UpdatePasswordAsync(UpdateUserPasswordDto user);
        Task<BaseResponse<bool>> DeleteAsync(DeleteUserProfileDto user);
    }
}
