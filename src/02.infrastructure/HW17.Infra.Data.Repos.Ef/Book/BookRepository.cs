using HW17.Domain.Contracts.Repositories;
using HW17.Domain.Core.DTOs.BookDtos;
using HW17.Domain.Core.Entities;
using HW17.Infrastructure.EfCore.Persistence;

namespace HW17.Infrastructure.EfCore.Repositories
{
    public class BookRepository(AppDbContext _context) : IBookRepository
    {
        public List<GetBookDtos> GetNewestBooks()
        {
            return _context.Books.OrderByDescending(b => b.Id)
                .Take(5)
                .Select(b => new GetBookDtos
                {
                    Auther = b.Auther,
                    PageCount = b.PageCount,
                    Price = b.Price,
                    Title = b.Title,
                    ImagePath = b.ImagePath
                }).ToList();
        }
        public List<GetBookDtos> GetBooks()
        {
            return _context.Books
               .Select(b => new GetBookDtos
               {
                   Auther = b.Auther,
                   PageCount = b.PageCount,
                   Price = b.Price,
                   Title = b.Title,
                   ImagePath = b.ImagePath
               })
               .ToList();
        }

        public void Add(CreateBookDto book)
        {
            var bookEntity = new Book
            {

                Title = book.Title,
                Auther = book.Auther,
                CategoryId = book.CategoryId,
                CreatedAt = DateTime.Now,
                ImagePath = book.ImagePath,
                Price = book.Price,
                PageCount = book.PageCount,

            };
            _context.Books.Add(bookEntity);
            _context.SaveChanges();
        }
    }
}
