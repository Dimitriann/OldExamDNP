using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IAuthorService
    {
        Task<IList<Author>> GetAuthors();
        Task<Author> AddAuthor(Author author);
    }
}