using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BookServiceSQLITE : IBookService
    {
        private BookStoreDbContext StoreDbContext;

        public BookServiceSQLITE(BookStoreDbContext bookStoreDbContext)
        {
            StoreDbContext = bookStoreDbContext;
        }
        public async Task<IList<Book>> GetBooks()
        {
            IList<Book> allBooks = await StoreDbContext.Books.ToListAsync();
            return allBooks;
        }

        public async Task<Book> AddBook(int AuthorId, Book book)
        {
            book.AuthorId = AuthorId;
            await StoreDbContext.Books.AddAsync(book);
            await StoreDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBook(int ISBN)
        {
            Book toRemove = await StoreDbContext.Books.FirstAsync(a => a.ISBN==ISBN);
            Console.WriteLine(JsonSerializer.Serialize(toRemove));
            StoreDbContext.Remove(toRemove);
            await StoreDbContext.SaveChangesAsync();
            return toRemove;
        }
    }
}