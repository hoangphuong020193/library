using System.Threading.Tasks;
using Library.Data.Services;
using Library.Library.UserAccount.ViewModels;
using Library.Data.Entities.Account;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Library.UserAccount.Queries.GetUserByUserName
{
    public class GetUserByUserNameQuery : IGetUserByUserNameQuery
    {
        private readonly IRepository<User> _userRepository;

        public GetUserByUserNameQuery(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserLoginViewModel> ExecuteAsync(string userName)
        {
            var user = await _userRepository
                .TableNoTracking
                .Where(x => x.UserName == userName && x.Enabled.Value)
                .Select(x => new UserLoginViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    PassWord = x.PassWord,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName
                }).FirstOrDefaultAsync();
            return user;
        }
    }
}
