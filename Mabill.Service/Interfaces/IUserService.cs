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
        BaseResponse<User> GetAsync(Expression<Func<User, bool>> expression);
        Task<BaseResponse<User>> CreateAsync(CreateUserDto createUserDto);
        Task<BaseResponse<User>> UpdateProfileAsync(UpdateUserProfileDto updateUserProfileDto);
        Task<BaseResponse<bool>> UpdatePasswordAsync(UpdateUserPasswordDto updateUserPasswordDto);
        Task<BaseResponse<bool>> DeleteAsync(DeleteUserProfileDto deleteUserDto);
    }
}
