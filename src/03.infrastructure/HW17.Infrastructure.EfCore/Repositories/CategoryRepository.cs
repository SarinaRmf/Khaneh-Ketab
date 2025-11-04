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
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
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

        public bool Update(int categoryId, GetCategoryDto CategoryDto)
        {
            var result = _context.Categories
                .Where(c => c.Id == categoryId)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(c => c.Name, CategoryDto.Name)
                .SetProperty(c => c.Description, CategoryDto.Description)
                .SetProperty(c => c.ImagePath, CategoryDto.ImagePath)
                .SetProperty(c => c.UptatedAt, DateTime.Now));

            return true;

        }
        public GetCategoryDto? GetCategoryById(int categoryId)
        {
            return _context.Categories.Where(c => c.Id == categoryId)
                .AsNoTracking()
                .Select(c => new GetCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,    
                    ImagePath = c.ImagePath,
                }).FirstOrDefault();
        }

        public string GetImageProfileUrl(int categoryId)
        {
            var imgAddress = _context.Categories
                .Where(c => c.Id == categoryId)
                .Select(c => c.ImagePath)
                .FirstOrDefault();


            return imgAddress;
        }
    }
}
