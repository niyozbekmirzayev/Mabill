using AutoMapper;
using Mabill.Data.IRepositories;
using Mabill.Domain.Base;
using Mabill.Domain.Entities.Users;
using Mabill.Domain.Enums;
using Mabill.Service.Dtos.Users;
using Mabill.Service.Extensions;
using Mabill.Service.Helpers;
using Mabill.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mabill.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private IUserRepository userRepository;
        private HttpContextHelper httpContextHelper;

        public UserService(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextHelper = new HttpContextHelper(httpContextAccessor);
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<User>> CreateAsync(CreateUserDto user)
        {
            var response = new BaseResponse<User>();

            #region Date validation
            if (user == null)
            {
                response.Error = new BaseError(400, "User is null");

                return response;
            }

            if (!String.IsNullOrEmpty(user.Email))
            {
                var exsistEmail = await userRepository.GetAsync(x => x.Email == user.Email && x.Status != ObjectStatus.Deleted);

                if (exsistEmail != null)
                {
                    response.Error = new BaseError(409, "User with same email already exists");

                    return response;
                }
            }

            var exsitUsername = await userRepository.GetAsync(x => x.Username == user.Username.ToLower() && x.Status != ObjectStatus.Deleted);
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

            user.Username = user.Username.ToLower();
            var newUser = mapper.Map<User>(user);
            newUser.Create();
            newUser.Password = newUser.Password.EncodeInSha256();
            var createdUser = await userRepository.CreateAsync(newUser);

            response.Data = createdUser;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(DeleteUserProfileDto user)
        {
            var response = new BaseResponse<bool>();

            #region Data validation
            if (user == null)
            {
                response.Error = new BaseError(400, "User is null");

                return response;
            }

            var currentUser = httpContextHelper.GetCurrentUser();

            var exsistUser = await userRepository.GetAsync(x => x.Id == currentUser.Id && x.Password == user.Password.EncodeInSha256() &&
                                                           x.Status != ObjectStatus.Deleted);
            if (exsistUser == null)
            {
                response.Error = new BaseError(400, "User is not found");

                return response;
            }
            #endregion

            exsistUser.Delete();
            await userRepository.UpdateAsync(exsistUser);
            response.Data = true;

            return response;
        }

        public BaseResponse<IEnumerable<User>> GetAll(Expression<Func<User, bool>> expression)
        {
            var response = new BaseResponse<IEnumerable<User>>();

            var users = userRepository.GetAll(expression).AsEnumerable();

            response.Data = users;

            return response;
        }

        public async Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression)
        {
            var response = new BaseResponse<User>();

            var user = await userRepository.GetAsync(expression);

            if (user == null)
            {
                response.Error = new BaseError(404, "User not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<User>> UpdateProfileAsync(UpdateUserProfileDto user)
        {
            var response = new BaseResponse<User>();

            #region Data validation
            if (user == null)
            {
                response.Error = new BaseError(400, "User is null");

                return response;
            }

            var currentUser = httpContextHelper.GetCurrentUser();

            var exsistUser = await userRepository.GetAsync(x => x.Id == currentUser.Id && x.Status != ObjectStatus.Deleted);

            if (exsistUser == null)
            {
                response.Error = new BaseError(404, "User not found");

                return response;
            }

            if (!String.IsNullOrEmpty(user.Email))
            {
                var exsistEmail = await userRepository.GetAsync(x => x.Email == user.Email && x.Status != ObjectStatus.Deleted);

                if (exsistEmail != null && exsistEmail.Id != currentUser.Id)
                {
                    response.Error = new BaseError(409, "User with same email already exists");

                    return response;
                }
            }


            if (!String.IsNullOrEmpty(user.Username))
            {
                var exsitUsername = await userRepository.GetAsync(x => x.Username == user.Username.ToLower() && x.Status != ObjectStatus.Deleted);

                if (exsitUsername != null && exsitUsername.Id != currentUser.Id)
                {
                    response.Error = new BaseError(409, "User with same username already exists");

                    return response;
                }
            }

            if (!String.IsNullOrEmpty(user.PhoneNumber))
            {
                var exsitPhoneNumber = await userRepository.GetAsync(x => x.PhoneNumber == user.PhoneNumber && x.Status != ObjectStatus.Deleted);

                if (exsitPhoneNumber != null && exsitPhoneNumber.Id != currentUser.Id)
                {
                    response.Error = new BaseError(409, "User with same phone number already exists");

                    return response;
                }
            }
            #endregion

            var mappedUser = mapper.Map(user, exsistUser);
            mappedUser.Modify();
            var updatedUser = await userRepository.UpdateAsync(mappedUser);
            response.Data = updatedUser;

            return response;
        }

        public async Task<BaseResponse<bool>> UpdatePasswordAsync(UpdateUserPasswordDto user)
        {
            var response = new BaseResponse<bool>();

            #region Data validation
            if (user == null)
            {
                response.Error = new BaseError(400, "User is null");

                return response;
            }

            var currentUser = httpContextHelper.GetCurrentUser();

            var exsistUser = await userRepository.GetAsync(x => x.Id == currentUser.Id && x.Password == user.Password.EncodeInSha256() &&
                                                           x.Status != ObjectStatus.Deleted);

            if (exsistUser == null)
            {
                response.Error = new BaseError(400, "Password did not match");

                return response;
            }
            #endregion

            exsistUser.Password = user.NewPassword.EncodeInSha256();
            exsistUser.Modify();
            await userRepository.UpdateAsync(exsistUser);
            response.Data = true;

            return response;
        }
    }
}
