using HW17.Domain.Core.DTOs.BookDtos;

namespace HW17.Domain.Contracts.Repositories
{
    public interface IBookRepository
    {
        List<GetBookDtos> GetNewestBooks();
        List<GetBookDtos> GetBooks();
        void Add(CreateBookDto book);
    }
}
