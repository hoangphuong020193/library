using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Common.Enum;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Book.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Book.Queries.GetListBookByRequestCode
{
    public class GetListBookByRequestCodeQuery : IGetListBookByRequestCodeQuery
    {
        private readonly IRepository<UserBooks> _userBookRepository;

        public GetListBookByRequestCodeQuery(IRepository<UserBooks> userBookRepository)
        {
            _userBookRepository = userBookRepository;
        }

        public async Task<List<BookBorrowViewModel>> ExecuteAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return new List<BookBorrowViewModel>();
            }

            var result = await _userBookRepository.TableNoTracking
                    .Include(x => x.Book)
                    .Include(x => x.User)
                    .Include(x => x.Request)
                    .Where(x => (x.Request.RequestCode == code || x.User.UserName == code)
                    && (x.Status == (int)BookStatus.Pending || x.Status == (int)BookStatus.Borrowing || x.Status == (int)BookStatus.Returned))
                    .Select(x => new BookBorrowViewModel
                    {
                        BookCode = x.Book.BookCode,
                        BookName = x.Book.BookName,
                        RequestCode = x.Request.RequestCode,
                        RequestDate = x.Request.RequestDate,
                        ReceiveDate = x.ReceiveDate,
                        ReturnDate = x.ReturnDate,
                        Status = x.Status,
                        DeadlineDate = x.DeadlineDate
                    }).OrderByDescending(x => x.DeadlineDate).ToListAsync();
            return result;
        }
    }
}
