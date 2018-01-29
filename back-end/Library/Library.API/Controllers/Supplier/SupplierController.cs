using Library.Library.Suppliers.Queries.GetListSupplier;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers.Publisher
{
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        private readonly IGetListSupplier _getListSupplier;

        public SupplierController(
             IGetListSupplier getListSupplier)
        {
            _getListSupplier = getListSupplier;
        }

        [HttpGet]
        [Route("ReturnListSupplier")]
        public async Task<IActionResult> ReturnListSupplierAsync()
        {
            var result = await _getListSupplier.ExecuteAsync();
            return new ObjectResult(result);
        }
    }
}
