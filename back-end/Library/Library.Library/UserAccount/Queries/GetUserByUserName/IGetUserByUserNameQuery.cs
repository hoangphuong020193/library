using Library.Library.UserAccount.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.UserAccount.Queries.GetUserByUserName
{
    public interface IGetUserByUserNameQuery
    {
        Task<UserLoginViewModel> ExecuteAsync(string userName);
    }
}
