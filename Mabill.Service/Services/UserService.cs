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
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserRepository userRepository;
        private readonly HttpContextHelper httpContextHelper;

        public UserService(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            httpContextHelper = new HttpContextHelper(httpContextAccessor);
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<User>> CreateAsync(CreateUserDto createUserDto)
        {
            var response = new BaseResponse<User>();

            #region Date validation
            if (createUserDto == null)
            {
                response.Error = new BaseError(400, "User is null");

                return response;
            }

            if (!String.IsNullOrEmpty(createUserDto.Email))
            {
                var exsistEmail = await userRepository.GetAsync(x => x.Email == createUserDto.Email && x.Status != ObjectStatus.Deleted);

                if (exsistEmail != null)
                {
                    response.Error = new BaseError(409, "User with same email already exists");

                    return response;
                }
            }

            var exsitUsername = await userRepository.GetAsync(x => x.Username == createUserDto.Username.ToLower() && x.Status != ObjectStatus.Deleted);
            if (exsitUsername != null)
            {
                response.Error = new BaseError(409, "User with same username already exists");

                return response;
            }

            var exsitPhoneNumber = await userRepository.GetAsync(x => x.PhoneNumber == createUserDto.PhoneNumber && x.Status != ObjectStatus.Deleted);
            if (exsitPhoneNumber != null)
            {
                response.Error = new BaseError(409, "User with same phone number already exists");

                return response;
            }
            #endregion

            createUserDto.Username = createUserDto.Username.Trim().ToLower();
            var newUser = mapper.Map<User>(createUserDto);
            newUser.Create();
            newUser.Password = newUser.Password.EncodeInSha256();
            var createdUser = await userRepository.CreateAsync(newUser);

            response.Data = createdUser;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(DeleteUserProfileDto deleteUserDto)
        {
            var response = new BaseResponse<bool>();

            #region Data validation
            if (deleteUserDto == null)
            {
                response.Error = new BaseError(400, "User is null");

                return response;
            }

            var currentUser = httpContextHelper.GetCurrentUser();

            var exsistUser = await userRepository.GetAsync(x => x.Id == currentUser.Id && x.Password == deleteUserDto.Password.EncodeInSha256() &&
                                                           x.Status != ObjectStatus.Deleted);
            if (exsistUser == null)
            {
                response.Error = new BaseError(404, "User is not found");

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

            var user = await userRepository.GetAll(expression).Include(user => user.Occupations).Include(user => user.BalanceInJournals).FirstOrDefaultAsync();

            if (user == null)
            {
                response.Error = new BaseError(404, "User not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<User>> UpdateProfileAsync(UpdateUserProfileDto updateUserProfileDto)
        {
            var response = new BaseResponse<User>();

            #region Data validation
            if (updateUserProfileDto == null)
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

            if (!String.IsNullOrEmpty(updateUserProfileDto.Email))
            {
                var exsistEmail = await userRepository.GetAsync(x => x.Email == updateUserProfileDto.Email && x.Status != ObjectStatus.Deleted);

                if (exsistEmail != null && exsistEmail.Id != currentUser.Id)
                {
                    response.Error = new BaseError(409, "User with same email already exists");

                    return response;
                }
            }


            if (!String.IsNullOrEmpty(updateUserProfileDto.Username))
            {
                var exsitUsername = await userRepository.GetAsync(x => x.Username == updateUserProfileDto.Username.ToLower() && x.Status != ObjectStatus.Deleted);

                if (exsitUsername != null && exsitUsername.Id != currentUser.Id)
                {
                    response.Error = new BaseError(409, "User with same username already exists");

                    return response;
                }
            }

            if (!String.IsNullOrEmpty(updateUserProfileDto.PhoneNumber))
            {
                var exsitPhoneNumber = await userRepository.GetAsync(x => x.PhoneNumber == updateUserProfileDto.PhoneNumber && x.Status != ObjectStatus.Deleted);

                if (exsitPhoneNumber != null && exsitPhoneNumber.Id != currentUser.Id)
                {
                    response.Error = new BaseError(409, "User with same phone number already exists");

                    return response;
                }
            }
            #endregion

            var mappedUser = mapper.Map(updateUserProfileDto, exsistUser);
            mappedUser.Modify();
            var updatedUser = await userRepository.UpdateAsync(mappedUser);
            response.Data = updatedUser;

            return response;
        }

        public async Task<BaseResponse<bool>> UpdatePasswordAsync(UpdateUserPasswordDto updateUserPasswordDto)
        {
            var response = new BaseResponse<bool>();

            #region Data validation
            if (updateUserPasswordDto == null)
            {
                response.Error = new BaseError(400, "User is null");

                return response;
            }

            var currentUser = httpContextHelper.GetCurrentUser();

            var exsistUser = await userRepository.GetAsync(x => x.Id == currentUser.Id && x.Password == updateUserPasswordDto.Password.EncodeInSha256() &&
                                                           x.Status != ObjectStatus.Deleted);

            if (exsistUser == null)
            {
                response.Error = new BaseError(400, "Password did not match");

                return response;
            }
            #endregion

            exsistUser.Password = updateUserPasswordDto.NewPassword.EncodeInSha256();
            exsistUser.Modify();
            await userRepository.UpdateAsync(exsistUser);
            response.Data = true;

            return response;
        }
    }
}
