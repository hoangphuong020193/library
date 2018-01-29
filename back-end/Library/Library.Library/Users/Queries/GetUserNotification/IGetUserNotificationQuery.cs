using Library.Library.Users.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Library.Users.Queries.GetUserNotification
{
    public interface IGetUserNotificationQuery
    {
        Task<List<UserNotificationViewModel>> ExecuteAsync();
    }
}
