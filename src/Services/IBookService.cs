using System.Collections.Generic;
using System.Threading.Tasks;
using cloudBackend.Models;

namespace cloudBackend.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
    }
}