using Assignment7.Application.Dtos;
using Assignment7.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Application.Mappers
{
    public static class BookMapper
    {
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto
            {
                Title = book.Title,
                ISBN = book.ISBN,
                Author = book.Author,
                Category = book.Category,
                Publisher = book.Publisher,
                Description = book.Description,
                Language = book.Language,
                Location = book.Location
            };
        }
    }
}
