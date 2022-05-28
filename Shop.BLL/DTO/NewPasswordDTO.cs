using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
    public class NewPasswordDTO
    {
        public string UserEmail { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
