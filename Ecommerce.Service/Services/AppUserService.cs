using AutoMapper;
using Ecommerce.DTOs.AppUsers;
using Ecommerce.Models.Models;
using Ecommerce.Repository.Contract;
using Ecommerce.Service.Contract;
using Ecommerce.Service.ExtensionMethods;
using Ecommerce.Service.Mapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository userRepo;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;

        public AppUserService(IAppUserRepository _userRepo,
            IMapper _mapper,
            UserManager<AppUser> _userManger,
            ITokenService _tokenService,
            SignInManager<AppUser> _signInManger)
        {
            userRepo = _userRepo;
            mapper = _mapper;
            userManager = _userManger;
            tokenService = _tokenService;
            signInManager = _signInManger;
        }


        public async Task<IEnumerable<GetAllUsersDTO>> GetAllUsers()
        {
            var allUsers = await userRepo.GetAll();
            return mapper.Map<IEnumerable<GetAllUsersDTO>>(allUsers);
        }

        public async Task<IEnumerable<GetAllUsersDTO>>? GetUserById(int id)
        {
            var user = await userRepo.GetOne(id);
            if (user == null)
            {
               return null;
            }
            else
            {
                return mapper.Map<IEnumerable<GetAllUsersDTO>>(user);
            }
        }

        public async Task<IEnumerable<GetAllUsersDTO>>? GetUserByUsername(string username)
        {
            var user = await userRepo.GetOne(username);
            if (user == null)
            {
                return null;
            }
            else
            {
                return mapper.Map<IEnumerable<GetAllUsersDTO>>(user);
            }
        }

        public async Task<object> Create(CreateOrUpdateUserDTO userDto)
        {
            try
            {

                var newUser = new AppUser()
                {
                    UserName = userDto.Username,
                    Email = userDto.Email,
                    Address = userDto.Address,
                    BirthDate = userDto.BirthDate.Value,
                    Card = userDto.Card
                };

                var createdUser = await userManager.CreateAsync(newUser, userDto.Password);
                if (createdUser.Succeeded)
                {
                    var createdRole = await userManager.AddToRoleAsync(newUser, "User");
                    if (createdRole.Succeeded)
                    {
                        return new UserDTO()
                        {
                            UserName = newUser.UserName,
                            Email = newUser.Email,
                            Token = await tokenService.CreateToken(newUser)
                        };
                    }
                    else
                    {
                        return createdRole.Errors;
                    }
                }
                else
                {
                    return createdUser.Errors;
                }
            }
            catch
            {
                return "Something went wrong";
            }
        }

        public async Task<object> Login(LogUserDTO logUser)
        {
            var foundUser = await userManager.Users.FirstOrDefaultAsync(
                    u => u.Email == logUser.Email);

            if (foundUser != null)
            {
                var chkPassword = await signInManager
                    .CheckPasswordSignInAsync(foundUser,logUser.Password, false);

                if (chkPassword.Succeeded)
                {
                    return new UserDTO()
                    {
                        Email = foundUser.Email,
                        UserName = foundUser.UserName,
                        Token = await tokenService.CreateToken(foundUser)
                    };
                }
                else
                {
                    return "Email not found and/or password is not correct.";
                }
            }
            else
            {
                return "Invalid Email";
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            var delUserList = await userRepo.GetOne(id);
            var delUser = delUserList.FirstOrDefault();

            if (delUser == null)
            {
                return false;
            }
            else
            {
                userRepo.Delete(delUser);
                await userRepo.Save();
                return true;
            }
        }
    }
}
