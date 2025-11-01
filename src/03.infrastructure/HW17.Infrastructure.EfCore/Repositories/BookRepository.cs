using HW17.Domain.Contracts.Repositories;
using HW17.Domain.DTOs;
using HW17.Domain.Entities;
using HW17.Infrastructure.EfCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Infrastructure.EfCore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository()
        {
            _context = new AppDbContext();
        }
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
