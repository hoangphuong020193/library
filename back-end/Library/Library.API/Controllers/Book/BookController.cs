using Library.Library.Books.Queries.GetListNewBook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers.Book
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IGetListBookNewQuery _getListBookNewQuery;

        public BookController(IGetListBookNewQuery getListBookNewQuery)
        {
            _getListBookNewQuery = getListBookNewQuery;
        }

        [HttpGet]
        [Route("ReturnListNewBook")]
        [AllowAnonymous]
        public async Task<IActionResult> ReturnListNewBookAsync()
        {
            var result = await _getListBookNewQuery.ExecuteAsync();
            return new ObjectResult(result);
        }
    }
}
