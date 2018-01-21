using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.CrossCutting.Command;
using Library.Common;
using Library.Common.Enum;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Cart.ViewModels;
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

        public async Task<CommandResult> ExecuteAsync(List<int> bookIds)
        {
            var userId = int.Parse(_httpContext?.User?.UserId());

            List<int> listBooKInCartExisted = await _bookCartRepository.TableNoTracking
                .Where(x => x.UserId == userId && bookIds.Contains(x.BookId.Value) && (x.Status == (int)BookStatus.InOrder || x.Status == (int)BookStatus.Waiting))
                .Select(x => x.BookId.Value)
                .ToListAsync();

            List<int> listBooKInCartNew = bookIds.Where(x => !listBooKInCartExisted.Contains(x)).ToList();

            if (!listBooKInCartNew.Any())
            {
                return CommandResult.Success;
            }

            List<BookCart> entities = new List<BookCart>();
            listBooKInCartNew.ForEach(x =>
            {
                BookCart entity = new BookCart();
                entity.BookId = x;
                entity.UserId = userId;
                entity.Status = (int)BookStatus.InOrder;
                entities.Add(entity);
            });
            await _bookCartRepository.InsertAsync(entities);

            return CommandResult.SuccessWithData(entities);
        }
    }
}
