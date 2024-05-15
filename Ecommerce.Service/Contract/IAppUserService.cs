using AutoMapper;
using Ecommerce.DTOs.AppUsers;
using Ecommerce.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Contract
{
    public interface IAppUserService
    {
        Task<IEnumerable<GetAllUsersDTO>> GetAllUsers();
        Task<IEnumerable<GetAllUsersDTO>> GetUserById(int id);
        Task<IEnumerable<GetAllUsersDTO>> GetUserByUsername(string username);
        Task<object> Create(CreateOrUpdateUserDTO userDto);
        Task<object> Login(LogUserDTO logUser);
        Task<bool> DeleteUser(int id);
    }
}
