using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cloudBackend.DataAccess;
using cloudBackend.Models;
using cloudBackend.Services;

namespace cloudBackend.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books
                .OrderByDescending(b => b.Id)
                .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            Console.WriteLine(book.Id);
            if(book == null) {
                return null;
            }

            var existingBook = await _context.Books.FindAsync(book.Id);
            if (existingBook == null)
            {
            Console.WriteLine("book.Id");
                return null;
            }

            Console.WriteLine(existingBook);
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Cover = book.Cover;
            existingBook.Comment = book.Comment;
            existingBook.Rating = book.Rating;

            _context.Entry(existingBook).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            Console.WriteLine("existingBook");
            return existingBook;
        }


        public async Task<bool> DeleteBookAsync(int id)
        {
            var bookToDelete = await _context.Books.FindAsync(id);
            if (bookToDelete == null)
            {
                return false;
            }

            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}