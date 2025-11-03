
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.DTOs
{
    public class UserLoginDto
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
