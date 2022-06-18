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
        BaseResponse<IEnumerable<User>> GetAll(Expression<Func<bool, User>> expression = null);
        Task<BaseResponse<User>> GetAsync(Expression<Func<bool, User>> expression);
        Task<BaseResponse<User>> CreateAsync(CreateUserDto user);
        Task<BaseResponse<User>> UpdateAysnc(User user);
        Task<bool> DeleteAsync(Guid id);
    }
}
