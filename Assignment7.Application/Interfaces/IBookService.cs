using Assignment7.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> SearchBookLanguage(string language);
        Task DeleteStampBook(int id, string deleteStatus);
    }
}
