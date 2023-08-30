using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserUseCase : BaseEntity
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
        public  User User { get; set; }
    }
}
