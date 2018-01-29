using Library.Library.Admin.Queries.GetListUserNotReturnBook;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers.User
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IGetListUserNotReturnBookQuery _getListUserNotReturnBookQuery;

        public AdminController(
            IGetListUserNotReturnBookQuery getListUserNotReturnBookQuery)
        {
            _getListUserNotReturnBookQuery = getListUserNotReturnBookQuery;
        }

        [HttpGet]
        [Route("ReturnListUserNotReturnBook/{page:int=0}/{pageSize:int=0}")]
        public async Task<IActionResult> ReturnListUserNotReturnBookAsync(int page, int pageSize)
        {
            var result = await _getListUserNotReturnBookQuery.ExecuteAsync(page, pageSize);
            return new ObjectResult(result);
        }
    }
}
