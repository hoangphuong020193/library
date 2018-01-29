using Library.Library.Categories.Queries.GetCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers.User
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IGetCategoryQuery _getCategoryQuery;

        public CategoryController(IGetCategoryQuery getCategoryQuery)
        {
            _getCategoryQuery = getCategoryQuery;
        }

        [HttpGet]
        [Route("ReturnCategory")]
        [AllowAnonymous]
        public async Task<IActionResult> ReturnCategoryAsync()
        {
            var result = await _getCategoryQuery.ExecuteAsync();
            return new ObjectResult(result);
        }
    }
}
