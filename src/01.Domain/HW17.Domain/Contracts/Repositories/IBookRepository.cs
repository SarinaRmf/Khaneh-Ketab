using HW17.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.Contracts.Repositories
{
    public interface IBookRepository
    {
        List<GetBookDtos> GetNewestBooks();
    }
}
