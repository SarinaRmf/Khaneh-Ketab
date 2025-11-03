using HW17.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        List<GetCategoryDto> GetCategories();
        void Delete(int categoryId);
        bool Add(CreateCategoryDto categoryDto);
        bool ExistBefore(string categoryName);
    }
}
