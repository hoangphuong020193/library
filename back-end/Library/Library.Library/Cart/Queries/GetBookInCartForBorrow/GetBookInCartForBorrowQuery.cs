using Library.Library.Cart.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Common;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Library.Common.Enum;
using System;

namespace Library.Library.Cart.Queries.GetBookInCartForBorrow
{
    public class GetBookInCartForBorrowQuery : IGetBookInCartForBorrowQuery
    {
        private readonly IRepository<BookCart> _bookCartRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly HttpContext _httpContext;

        public GetBookInCartForBorrowQuery(
            IRepository<BookCart> bookCartRepository,
            IRepository<Book> bookRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _bookCartRepository = bookCartRepository;
            _bookRepository = bookRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<List<BookInCartDetailViewModel>> ExecuteAsync()
        {
            var userId = int.Parse(_httpContext?.User?.UserId());
            var result = await (from cart in _bookCartRepository.TableNoTracking.Where(x => x.UserId == userId && x.Status == (int)BookStatus.InOrder)
                                join book in _bookRepository.TableNoTracking on cart.BookId equals book.Id
                                select new BookInCartDetailViewModel
                                {
                                    BookId = book.Id,
                                    BookCode = book.BookCode,
                                    BookName = book.BookName,
                                    Author = book.Author,
                                    Amoun = book.Amount.Value,
                                    AmountAvailable = book.AmountAvailable.Value,
                                    MaximumDateBorrow = book.MaximumDateBorrow,
                                    ModifiedDate = cart.ModifiedDate.Value,
                                    Status = cart.Status,
                                    ReturnDate = DateTime.Now.Date.AddDays(book.MaximumDateBorrow + 1)
                                }).ToListAsync();

            return result;
        }
    }
}
