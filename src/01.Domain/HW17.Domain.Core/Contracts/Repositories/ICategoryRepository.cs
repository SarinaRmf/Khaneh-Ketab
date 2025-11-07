using HW17.Domain.Core.DTOs.CategoryDtos;

namespace HW17.Domain.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        List<GetCategoryDto> GetCategories();
        void Delete(int categoryId);
        bool Add(CreateCategoryDto categoryDto);
        bool ExistBefore(string categoryName);
        GetCategoryDto? GetCategoryById(int categoryId);
        bool Update(int categoryId, GetCategoryDto CategoryDto);
        string GetImageProfileUrl(int categoryId);
    }
}
