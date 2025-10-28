using HW17.Domain.Contracts.Repositories;
using HW17.Domain.Contracts.Services;
using HW17.Domain.DTOs;
using HW17.Infrastructure.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _repository;
        public CategoryServices()
        {
            _repository = new CategoryRepository();
        }
        public List<GetCategoryDto> GetCategories() { 
            return _repository.GetCategories();
        }
    }
}
