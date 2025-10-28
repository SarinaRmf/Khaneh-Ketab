using HW17.Domain.Contracts.Repositories;
using HW17.Domain.DTOs;
using HW17.Infrastructure.EfCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Infrastructure.EfCore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository()
        {
            _context = new AppDbContext();
        }
        public List<GetCategoryDto> GetCategories() 
        { 
            return _context.Categories.Select(c => new GetCategoryDto
            {
                Name = c.Name,
                Description = c.Description,
                ImagePath = c.ImagePath,
            }).ToList();
        }
    }
}
