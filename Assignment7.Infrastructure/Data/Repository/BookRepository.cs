﻿using Assignment7.Domain.Entities;
using Assignment7.Domain.Helpers;
using Assignment7.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Infrastructure.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibrarySystemContext _context;

        public BookRepository(LibrarySystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();

            return books;

        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Book>> SearchBookAsync(QueryObject query, Pagination pagination)
        {
            var books = _context.Books.AsQueryable();

            if (query.QueryOperators.Equals("OR", StringComparison.OrdinalIgnoreCase))
            {
                books = books.Where(b =>
                    (!string.IsNullOrEmpty(query.Title) && b.Title.ToLower().Contains(query.Title.ToLower())) ||
                    (!string.IsNullOrEmpty(query.Author) && b.Author.ToLower().Contains(query.Author.ToLower())) ||
                    (!string.IsNullOrEmpty(query.ISBN) && b.ISBN.ToLower().Contains(query.ISBN.ToLower())) ||
                    (!string.IsNullOrEmpty(query.Category) && b.Category.ToLower().Contains(query.Category.ToLower()))
                    );
            }
            else
            {
                if (!string.IsNullOrEmpty(query.Title))
                    books = books.Where(b => b.Title.ToLower().Contains(query.Title.ToLower()));
                if (!string.IsNullOrEmpty(query.Title))
                    books = books.Where(b => b.Author.ToLower().Contains(query.Author.ToLower()));
                if (!string.IsNullOrEmpty(query.ISBN))
                    books = books.Where(b => b.ISBN.ToLower().Contains(query.ISBN.ToLower()));
                if (!string.IsNullOrEmpty(query.Category))
                    books = books.Where(b => b.Category.ToLower().Contains(query.Category.ToLower()));
            }
            books = books.OrderBy(b => b.Title);

            var skipNumber = (pagination.PageNumber - 1) * pagination.PageSize;

            return await books.Skip(skipNumber).Take(pagination.PageSize).ToListAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}