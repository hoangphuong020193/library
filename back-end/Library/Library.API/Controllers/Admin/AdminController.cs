using Library.Library.Admin.Queries.GetListUserNotReturnBook;
using Library.Library.Admin.Queries.GetReadStatistic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers.User
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IGetListUserNotReturnBookQuery _getListUserNotReturnBookQuery;
        private readonly IReadStatisticQuery _readStatisticQuery;

        public AdminController(
            IGetListUserNotReturnBookQuery getListUserNotReturnBookQuery,
            IReadStatisticQuery readStatisticQuery)
        {
            _getListUserNotReturnBookQuery = getListUserNotReturnBookQuery;
            _readStatisticQuery = readStatisticQuery;
        }

        [HttpGet]
        [Route("ReturnListUserNotReturnBook/{page:int=0}/{pageSize:int=0}")]
        public async Task<IActionResult> ReturnListUserNotReturnBookAsync(int page, int pageSize)
        {
            var result = await _getListUserNotReturnBookQuery.ExecuteAsync(page, pageSize);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("ReturnListReadStatistic/{page:int=0}/{pageSize:int=0}")]
        public async Task<IActionResult> ReturnListReadStatisticAsync(int page, int pageSize, string startDate, string endDate, int groupBy)
        {
            var result = await _readStatisticQuery.ExecuteAsync(page, pageSize, startDate, endDate, groupBy);
            return new ObjectResult(result);
        }
    }
}
