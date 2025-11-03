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
        private readonly FileService _fileService;
        public CategoryServices()
        {
            _repository = new CategoryRepository();
            _fileService = new FileService();
        }

        public ResultDto<bool> Add(CreateCategoryDto createCategoryDto)
        {
            if (_repository.ExistBefore(createCategoryDto.Name)){

                return new ResultDto<bool> { IsSuccess = false, Message = "دسته بندی از قبل موجود است" };
            }
            createCategoryDto.ImagePath = _fileService.Upload(createCategoryDto.Imgfile, "Category");
            var result = _repository.Add(createCategoryDto);
            return new ResultDto<bool> { IsSuccess = true};
        }

        public void Delete(int categoryId)
        {
            _repository.Delete(categoryId);
        }

        public List<GetCategoryDto> GetCategories() { 
            return _repository.GetCategories();
        }
    }
}
