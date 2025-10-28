using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.DTOs
{
    public class GetCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
