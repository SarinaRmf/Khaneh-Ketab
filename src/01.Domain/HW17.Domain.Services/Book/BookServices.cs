using HW17.Domain.Contracts.Repositories;
using HW17.Domain.Core.Contracts.Services;
using HW17.Domain.Core.DTOs.BookDtos;

namespace HW17.Services
{
    public class BookServices(IBookRepository _repository, IFileService _fileService) : IBookService
    {
        public List<GetBookDtos> GetNewestBooks()
        {

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
