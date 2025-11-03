using HW17.Domain.Contracts.Repositories;
using HW17.Domain.DTOs;
using HW17.Domain.Entities;
using HW17.Infrastructure.EfCore.Persistence;
using Microsoft.EntityFrameworkCore;
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
                Id = c.Id,  
                Name = c.Name,
                Description = c.Description,
                ImagePath = c.ImagePath,
            }).ToList();
        }
        public void Delete(int categoryId)
        {

            _context.Categories.Where(c => c.Id == categoryId).ExecuteDelete();
        }

        public bool Add(CreateCategoryDto categoryDto)
        {
            var entity = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                ImagePath = categoryDto.ImagePath,
                CreatedAt = DateTime.Now,

            };
            _context.Categories.Add(entity);    
            return _context.SaveChanges() > 0;
        }

        public bool ExistBefore(string categoryName)
        {
            return _context.Categories.Any(c => c.Name == categoryName);
        }
    }
}
