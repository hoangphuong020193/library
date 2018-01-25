using Library.Library.Users.Queries.GetUserNotification;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers.User
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IGetUserNotificationQuery _getUserNotificationQuery;

        public UserController(IGetUserNotificationQuery getUserNotificationQuery)
        {
            _getUserNotificationQuery = getUserNotificationQuery;
        }

        [HttpGet]
        [Route("ReturnUserNotification")]
        public async Task<IActionResult> ReturnUserNotificationAsync()
        {
            var result = await _getUserNotificationQuery.ExecuteAsync();
            return new ObjectResult(result);
        }
    }
}
