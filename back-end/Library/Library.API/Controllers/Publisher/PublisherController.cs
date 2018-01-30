using Library.Library.Publishers.Commands.SavePublisher;
using Library.Library.Publishers.Queries.GetListPublisher;
using Library.Library.Publishers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers.Publisher
{
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        private readonly IGetListPublisherQuery _getListPublisherQuery;
        private readonly ISavePublisherCommand _savePublisherCommand;

        public PublisherController(
            IGetListPublisherQuery getListPublisherQuery,
            ISavePublisherCommand savePublisherCommand)
        {
            _getListPublisherQuery = getListPublisherQuery;
            _savePublisherCommand = savePublisherCommand;
        }

        [HttpGet]
        [Route("ReturnListPublisher")]
        public async Task<IActionResult> ReturnListPublisherAsync()
        {
            var result = await _getListPublisherQuery.ExecuteAsync();
            return new ObjectResult(result);
        }

        [HttpPost]
        [Route("SavePublisher")]
        public async Task<IActionResult> SavePublisherAsync([FromBody] PublisherViewModel model)
        {
            var result = await _savePublisherCommand.ExecuteAsync(model);
            return new ObjectResult(result.Data);
        }
    }
}
