using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<OrderMember> OrderMembers { get; set; }
    }
}
