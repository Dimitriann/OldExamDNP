using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public interface IAuthorController
    {
        Task<ActionResult<Author>> AddAuthor([FromBody] Author author);
        Task<ActionResult<IList<Author>>> GetAuthors();
    }
}