﻿using Assignment7.Domain.Entities;
using Assignment7.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Infrastructure.Data.Repository
{
    public class BookRequestRepository:IBookRequestRepository
    {
        private readonly LibrarySystemContext _context;

        public BookRequestRepository(LibrarySystemContext context)
        {
            _context = context;
        }

        public async Task<BookRequest> AddAsync(BookRequest bookRequest)
        {
            await _context.BookRequests.AddAsync(bookRequest);
            await _context.SaveChangesAsync();
            return bookRequest;
        }

        public async Task DeleteAsync(int id)
        {
            var req = await _context.BookRequests.FindAsync(id);
            _context.BookRequests.Remove(req);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookRequest>> GetAllAsync()
        {
            return await _context.BookRequests.ToListAsync(); 
        }

        public async Task<BookRequest> GetAsync(int id)
        {
            var req = await _context.BookRequests.FindAsync(id);
            return req;
        }

        public async Task<BookRequest> UpdateAsync(BookRequest bookRequest)
        {
            _context.BookRequests.Update(bookRequest);
            await _context.SaveChangesAsync();
            return bookRequest;
        }
    }
}