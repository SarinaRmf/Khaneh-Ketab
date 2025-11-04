using HW17.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.Contracts.Services
{
    public interface ICategoryServices
    {
        List<GetCategoryDto> GetCategories();
        void Delete(int categoryId);
        ResultDto<bool> Add(CreateCategoryDto createCategoryDto);
        GetCategoryDto? GetCategoryById(int categoryId);
        bool Update(int categoryId, GetCategoryDto CategoryDto);

    }
}
