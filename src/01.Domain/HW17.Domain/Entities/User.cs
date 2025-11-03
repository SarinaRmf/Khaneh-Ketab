using HW17.Domain._common.Entities;

using HW17.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public Mobile Phone { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; }
        public string? ProfilePath { get; set; }
    }
}
