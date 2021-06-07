using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace ExOld.Data
{
    public interface IBookService
    {
        Task<IList<Book>> GetBooks();
        Task<Book> AddBook(int AuthorId, Book book);
        Task<Book> DeleteBook(int ISBN);
    }
}