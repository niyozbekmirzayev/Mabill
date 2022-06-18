using AutoMapper;
using Mabill.Data.IRepositories;
using Mabill.Domain.Base;
using Mabill.Domain.Entities.Users;
using Mabill.Domain.Enums;
using Mabill.Service.Dtos.Users;
using Mabill.Service.Extensions;
using Mabill.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mabill.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<User>> CreateAsync(CreateUserDto user)
        {
            var response = new BaseResponse<User>();

            if (user == null)
            {
                response.Error = new BaseError(400, "User is null");

                return response;
            }

            #region Conflict validation
            if (!String.IsNullOrEmpty(user.Email))
            {
                var exsistEmail = await userRepository.GetAsync(x => x.Email == user.Email && x.Status != ObjectStatus.Deleted);

                if (exsistEmail != null)
                {
                    response.Error = new BaseError(409, "User with same email already exists");

                    return response;
                }
            }

            var exsitUsername = await userRepository.GetAsync(x => x.Username == user.Username && x.Status != ObjectStatus.Deleted);
            if (exsitUsername != null)
            {
                response.Error = new BaseError(409, "User with same username already exists");

                return response;
            }

            var exsitPhoneNumber = await userRepository.GetAsync(x => x.PhoneNumber == user.PhoneNumber && x.Status != ObjectStatus.Deleted);
            if (exsitPhoneNumber != null)
            {
                response.Error = new BaseError(409, "User with same phone number already exists");

                return response;
            }
            #endregion

            var newUser = mapper.Map<User>(user);
            newUser.Create();
            newUser.Password = newUser.Password.EncodeInSha256();
            var createdUser = await userRepository.CreateAsync(newUser);

            response.Data = createdUser;

            return response;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<IEnumerable<User>> GetAll(Expression<Func<bool, User>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<User>> GetAsync(Expression<Func<bool, User>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<User>> UpdateAysnc(User user)
        {
            throw new NotImplementedException();
        }
    }
}
