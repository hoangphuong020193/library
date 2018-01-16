using Library.Library.Books.Queries.GetBookInCart;
using Library.Library.Cart.Commands.AddBookToCart;
using Library.Library.Cart.Commands.DeleteToCart;
using Library.Library.Cart.Commands.UpdateStatusBookInCart;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers.Cart
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly IGetBookInCartQuery _getBookInCartQuery;
        private readonly IAddBookToCartCommand _addBookToCartCommand;
        private readonly IDeleteToCartCommand _deleteToCartCommand;
        private readonly IUpdateStatusBookInCartCommand _updateStatusBookInCartCommand;

        public CartController(
            IGetBookInCartQuery getBookInCartQuery,
            IAddBookToCartCommand addBookToCartCommand,
            IDeleteToCartCommand deleteToCartCommand,
            IUpdateStatusBookInCartCommand updateStatusBookInCartCommand)
        {
            _getBookInCartQuery = getBookInCartQuery;
            _addBookToCartCommand = addBookToCartCommand;
            _deleteToCartCommand = deleteToCartCommand;
            _updateStatusBookInCartCommand = updateStatusBookInCartCommand;
        }

        [HttpGet]
        [Route("ReturnBookInCart")]
        public async Task<IActionResult> ReturnBookInCartAsync()
        {
            var result = await _getBookInCartQuery.ExecuteAsync();
            return new ObjectResult(result);
        }

        [HttpPost]
        [Route("AddBookInCart")]
        public async Task<IActionResult> AddBookInCartAsync([FromBody] int bookId)
        {
            var result = await _addBookToCartCommand.ExecuteAsync(bookId);
            return new ObjectResult(result);
        }

        [HttpDelete]
        [Route("DeleteBookInCart/{bookId:int}")]
        public async Task<IActionResult> DelteBookInCartAsync(int bookId)
        {
            var result = await _deleteToCartCommand.ExecuteAsync(bookId);
            return new ObjectResult(result);
        }

        [HttpPut]
        [Route("UpdateStatusBookInCart/{bookId:int}")]
        public async Task<IActionResult> UpdateStatusBookInCartAsync(int bookId, [FromBody] int status)
        {
            var result = await _updateStatusBookInCartCommand.ExecuteAsync(bookId, status);
            return new ObjectResult(result);
        }
    }
}
