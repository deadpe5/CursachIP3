using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
    public class AuthUserDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
