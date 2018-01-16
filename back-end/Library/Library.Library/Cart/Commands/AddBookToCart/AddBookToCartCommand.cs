using System.Linq;
using System.Threading.Tasks;
using HRM.CrossCutting.Command;
using Library.Common;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Books.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Cart.Commands.AddBookToCart
{
    public class AddBookToCartCommand : IAddBookToCartCommand
    {
        private readonly IRepository<BookCart> _bookCartRepository;
        private readonly HttpContext _httpContext;

        public AddBookToCartCommand(
            IRepository<BookCart> bookCartRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _bookCartRepository = bookCartRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<CommandResult> ExecuteAsync(int bookId)
        {
            var userId = int.Parse(_httpContext?.User?.UserId());

            BookInCartViewModel book = await _bookCartRepository.TableNoTracking
                .Include(x => x.Book)
                .Where(x => x.UserId == userId && x.BookId == bookId)
                .Select(x => new BookInCartViewModel
                {
                    BookId = x.BookId.Value,
                    BookCode = x.Book.BookCode,
                    BookName = x.Book.BookName,
                    Author = x.Book.Author,
                    Amoun = x.Book.Amount.Value,
                    AmountAvailable = x.Book.AmountAvailable.Value,
                    Status = x.Status,
                    ModifiedDate = x.ModifiedDate.Value

                }).FirstOrDefaultAsync();

            if (book != null)
            {
                return CommandResult.SuccessWithData(book);
            }
            else
            {
                BookCart entity = new BookCart();
                entity.BookId = bookId;
                entity.UserId = userId;
                await _bookCartRepository.InsertAsync(entity);

                book = await _bookCartRepository.TableNoTracking
                .Include(x => x.Book)
                .Where(x => x.UserId == userId && x.BookId == bookId)
                .Select(x => new BookInCartViewModel
                {
                    BookId = x.BookId.Value,
                    BookCode = x.Book.BookCode,
                    BookName = x.Book.BookName,
                    Author = x.Book.Author,
                    Amoun = x.Book.Amount.Value,
                    AmountAvailable = x.Book.AmountAvailable.Value,
                    Status = x.Status,
                    ModifiedDate = x.ModifiedDate.Value

                }).FirstOrDefaultAsync();

                return CommandResult.SuccessWithData(book);
            }
        }
    }
}
