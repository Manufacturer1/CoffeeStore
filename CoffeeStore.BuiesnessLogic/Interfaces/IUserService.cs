using CoffeeStore.BuiesnessLogic.DTO;
using CoffeeStore.BuiesnessLogic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoffeeStore.BuiesnessLogic.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDTO);
        Task<ClaimsIdentity> Authenticate(UserDTO userDTO);
        Task SetInitialData(UserDTO adminDto,List<string> roles);
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<OperationDetails> DeleteUserByUsername(string username);
        Task<UserDTO> GetUserById(string userId);
        Task<OperationDetails> UpdateClient(UserDTO user);
        Task<UserDTO> GetUserByUsername(string username);

    }
}
