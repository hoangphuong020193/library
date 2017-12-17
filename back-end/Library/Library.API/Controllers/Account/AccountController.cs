using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Library.UserAccount.Queries.GetUserByUserName;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Library.ApiFramework.Authentication;
using Microsoft.Extensions.Options;
using Library.ApiFramework.AppSetting.Options;
using Library.Common;
using Library.Library.UserAccount.ViewModels;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IGetUserByUserNameQuery _getUserByUserNameQuery;
        private readonly IOptionsSnapshot<JwtOptions> _jwtConfiguration;

        public AccountController(IGetUserByUserNameQuery getUserByUserNameQuery,
            IOptionsSnapshot<JwtOptions> jwtConfiguration)
        {
            _getUserByUserNameQuery = getUserByUserNameQuery;
            _jwtConfiguration = jwtConfiguration;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginViewModel model)
        {
            var employee = await _getUserByUserNameQuery.ExecuteAsync(model.UserName);
            if (employee == null)
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }

            if (string.Compare(model.PassWord.ToMD5(), employee.PassWord, StringComparison.OrdinalIgnoreCase) != 0)
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }

            var jwtOptions = _jwtConfiguration.Value;
            jwtOptions.ValidFor = TimeSpan.FromHours(24);
            var jwtUserAccount = new JwtUserAccount
            {
                UserName = employee.UserName,
                DisplayName = (employee.FirstName + " " + employee.MiddleName + " " + employee.LastName).Replace("  ", " "),
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName
            };

            return new ObjectResult(new { accessToken = jwtUserAccount.GenerateToken(jwtOptions) });
        }

        [HttpGet("PingAPI")]
        [AllowAnonymous]
        public string PingAPI()
        {
            return "Good";
        }
    }
}
