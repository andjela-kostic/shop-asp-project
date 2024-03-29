﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public int RoleId { get; set; } = 1;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<UserUseCase> UserUseCases { get; set; } = new List<UserUseCase>();

    }
}
