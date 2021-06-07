using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AuthorServiceSQLITE : IAuthorService
    {
        private BookStoreDbContext StoreDbContext;

        public AuthorServiceSQLITE(BookStoreDbContext bookStoreDbContext)
        {
            StoreDbContext = bookStoreDbContext;
        }
        
        public async Task<IList<Author>> GetAuthors()
        {
            IList<Author> AllAuthors = await StoreDbContext.Authors.Include(a => a.Books).ToListAsync();
            return AllAuthors;
        }

        public async Task<Author> AddAuthor(Author author)
        {
            await StoreDbContext.Authors.AddAsync(author);
            await StoreDbContext.SaveChangesAsync();
            return author;
        }
    }
}