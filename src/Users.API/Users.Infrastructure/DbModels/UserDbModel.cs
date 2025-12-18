using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.ValueObject;

namespace Users.Infrastructure.DbModels
{
    public  class UserDbModel
    {
        public UserDbModel() { }

        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Password Password { get; set; }

        public Email Email { get; set; }
        public bool IsActive { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
