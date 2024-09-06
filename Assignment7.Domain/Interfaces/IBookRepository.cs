using Assignment7.Domain.Entities;
using Assignment7.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
        Task<IEnumerable<Book>> SearchBookAsync(QueryObject query, Pagination pagination);
        Task SaveChangesAsync();
    }
}
