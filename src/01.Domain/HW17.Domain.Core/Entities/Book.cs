using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Auther { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string? ImagePath { get; set; }

    }
}
