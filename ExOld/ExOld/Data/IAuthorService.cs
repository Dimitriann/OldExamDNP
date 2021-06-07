using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace ExOld.Data
{
    public interface IAuthorService
    {
        Task<Author> AddAuthor(Author author);
        Task<IList<Author>> getAuthors();
    }
}