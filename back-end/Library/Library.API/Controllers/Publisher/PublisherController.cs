using Library.Library.Publishers.Queries.GetListPublisher;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers.Publisher
{
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        private readonly IGetListPublisherQuery _getListPublisherQuery;

        public PublisherController(
            IGetListPublisherQuery getListPublisherQuery)
        {
            _getListPublisherQuery = getListPublisherQuery;
        }

        [HttpGet]
        [Route("ReturnListPublisher")]
        public async Task<IActionResult> ReturnListPublisherAsync()
        {
            var result = await _getListPublisherQuery.ExecuteAsync();
            return new ObjectResult(result);
        }
    }
}
