using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public interface IAuthService
    {
        Task<AuthUserDTO> Authorize(LoginUserDTO userDTO);
    }
}
