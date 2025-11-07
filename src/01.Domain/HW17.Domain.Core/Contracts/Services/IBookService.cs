using HW17.Domain.Core.DTOs.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.Core.Contracts.Services
{
    public interface IBookService
    {
        List<GetBookDtos> GetNewestBooks();
        List<GetBookDtos> GetBooks();
        void Add(CreateBookDto dto);
    }
}
