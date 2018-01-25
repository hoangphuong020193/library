using HRM.CrossCutting.Command;
using Library.Constants;
using Library.Library.BookRequest.Queries.GetRequestInfoByCode;
using Library.Library.Books.Commands.TakenBook;
using Library.Library.Books.Queries.GetBookDetail;
using Library.Library.Books.Queries.GetBookPhoto;
using Library.Library.Books.Queries.GetBookSection;
using Library.Library.Books.Queries.GetBookViewByCategory;
using Library.Library.Books.Queries.GetListBookByRequestCode;
using Library.Library.Books.Queries.GetListNewBook;
using Library.Library.Favorites.Commands.UpdateBookFavorite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Library.API.Controllers.Book
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IGetListBookNewQuery _getListBookNewQuery;
        private readonly IGetBookDetailQuery _getBookDetailQuery;
        private readonly IGetBookPhotoQuery _getBookPhotoQuery;
        private readonly IUpdateBookFavoriteCommand _updateBookFavoriteCommand;
        private readonly IGetBookSectionQuery _getBookSectionQuery;
        private readonly IGetBookViewByCategoryQuery _getBookViewByCategoryQuery;
        private readonly IGetListBookByRequestCodeQuery _getListBookByRequestCodeQuery;
        private readonly IGetRequestInfoByCodeQuery _getRequestInfoByCodeQuery;
        private readonly ITakenBookCommand _takenBookCommand;

        public BookController(IGetListBookNewQuery getListBookNewQuery,
            IGetBookDetailQuery getBookDetailQuery,
            IGetBookPhotoQuery getBookPhotoQuery,
            IUpdateBookFavoriteCommand updateBookFavoriteCommand,
            IGetBookSectionQuery getBookSectionQuery,
            IGetBookViewByCategoryQuery getBookViewByCategoryQuery,
            IGetListBookByRequestCodeQuery getListBookByRequestCodeQuery,
            IGetRequestInfoByCodeQuery getRequestInfoByCodeQuery,
            ITakenBookCommand takenBookCommand)
        {
            _getListBookNewQuery = getListBookNewQuery;
            _getBookDetailQuery = getBookDetailQuery;
            _getBookPhotoQuery = getBookPhotoQuery;
            _updateBookFavoriteCommand = updateBookFavoriteCommand;
            _getBookSectionQuery = getBookSectionQuery;
            _getBookViewByCategoryQuery = getBookViewByCategoryQuery;
            _getListBookByRequestCodeQuery = getListBookByRequestCodeQuery;
            _getRequestInfoByCodeQuery = getRequestInfoByCodeQuery;
            _takenBookCommand = takenBookCommand;
        }

        [HttpGet]
        [Route("ReturnListNewBook")]
        [AllowAnonymous]
        public async Task<IActionResult> ReturnListNewBookAsync()
        {
            var result = await _getListBookNewQuery.ExecuteAsync();
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("ReturnBookDetail/{bookCode=}")]
        [AllowAnonymous]
        public async Task<IActionResult> ReturnBookDetailAsync(string bookCode)
        {
            var result = await _getBookDetailQuery.ExecuteAsync(bookCode);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("Photo/{bookCode=}")]
        [AllowAnonymous]
        public async Task<IActionResult> PhotoAsync(string bookCode)
        {
            var result = await _getBookPhotoQuery.ExecuteAsync(bookCode);
            return new ObjectResult(result);
        }

        [HttpPost]
        [Route("UserFavoriteBook")]
        public async Task<IActionResult> UserFavoriteBookAsync([FromBody] int bookId)
        {
            var result = await _updateBookFavoriteCommand.ExecuteAsync(bookId);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("ReturnTopBookInSection/{take:int=10}")]
        [AllowAnonymous]
        public async Task<IActionResult> ReturnTopBookInSectionAsync(int take, string sectionType)
        {
            var result = await _getBookSectionQuery.ExecuteAsync(sectionType, take);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("BookView/{page:int=0}/{pageSize:int=1}")]
        [AllowAnonymous]
        public async Task<IActionResult> BookViewAsync(int page, int pageSize, string view)
        {
            var result = await _getBookViewByCategoryQuery.ExecuteAsync(view, page, pageSize);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("ReturnListBookByCode")]
        public async Task<IActionResult> ReturnListBookByCodeAsync(string code)
        {
            var result = await _getListBookByRequestCodeQuery.ExecuteAsync(code);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("ReturnRequestInfo")]
        public async Task<IActionResult> ReturnRequestInfoAsync(string code)
        {
            var result = await _getRequestInfoByCodeQuery.ExecuteAsync(code);
            return new ObjectResult(result);
        }

        [HttpPut]
        [Route("TakenBook")]
        public async Task<IActionResult> TakenAsync([FromBody] JObject jsonObject)
        {
            int userId = int.Parse(jsonObject["userId"].ToString());
            string bookCode = jsonObject["bookCode"].ToString();
            int requestId = int.Parse(jsonObject["requestId"].ToString());

            var result = await _takenBookCommand.ExecuteAsync(userId, bookCode, requestId);
            return StatusCode(result.Succeeded ? (int)HttpStatusCode.OK : result.GetFirstErrorCode() ?? (int)HttpStatusCode.InternalServerError, result.Data);
        }
    }
}
