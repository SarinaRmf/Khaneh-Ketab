using HW17.Domain.Contracts.Repositories;
using HW17.Domain.Contracts.Services;
using HW17.Domain.DTOs;
using HW17.Domain.Entities;
using HW17.Infrastructure.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _repository;
        public BookServices()
        {
            _repository = new BookRepository();
        }
        public List<GetBookDtos> GetNewestBooks() {
        
            return _repository.GetNewestBooks();
        }
    }
}
