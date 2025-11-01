using HW17.Domain.Contracts.Repositories;
using HW17.Domain.Contracts.Services;
using HW17.Domain.DTOs;
using HW17.Domain.Entities;
using HW17.Infrastructure.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _repository;
        private readonly FileService _fileService;
        public BookServices()
        {
            _repository = new BookRepository();
            _fileService = new FileService();
        }
        public List<GetBookDtos> GetNewestBooks() {
        
            return _repository.GetNewestBooks();
        }
        public List<GetBookDtos> GetBooks()
        {
            return _repository.GetBooks();
        }

        public void Add(CreateBookDto bookDto)
        {

            var address = _fileService.Upload(bookDto.ImageFile, "books");
            bookDto.ImagePath = address;
            _repository.Add(bookDto);
        }
    }
}
