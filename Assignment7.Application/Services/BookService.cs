using Assignment7.Application.Interfaces;
using Assignment7.Domain.Entities;
using Assignment7.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Application.Services
{
    public class BookServices : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookServices(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> SearchBookLanguage(string language)
        {
            var languagebook = await _bookRepository.GetAllBooks();

            return languagebook
                .Where(book => book.Language == language)
                .ToList();
        }

        public async Task DeleteStampBook(int id, string deleteStatus)
        {
            var deleted = await _bookRepository.GetBookById(id);
            if (deleted == null)
            {
                throw new Exception($"Book with Id {id} not found");
            }
            deleted.DeleteStamp = true;
            deleted.DeleteStatus = deleteStatus;

            _bookRepository.UpdateBook(deleted);
            await _bookRepository.SaveChangesAsync();
        }
    }
}
