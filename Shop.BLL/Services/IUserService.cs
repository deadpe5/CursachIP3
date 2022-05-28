using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public interface IUserService
    {
        Task<AuthUserDTO> CreateUser(newUserDTO userDTO);
        Task<List<UserDTO>> GetAllUsersList();
        Task<UserDTO> GetUserByEmail(string userEmail);
        Task<List<UserDTO>> GetUsersByName(string userName);
        Task DeleteUser(string userEmail);
        Task UpdateUser(UserDTO user);
        Task ToggleRole(string userEmail);
        Task ChangePassword(NewPasswordDTO newPasswordDTO);
    }
}
