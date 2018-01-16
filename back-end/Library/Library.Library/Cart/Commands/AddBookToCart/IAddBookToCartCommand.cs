using HRM.CrossCutting.Command;
using System.Threading.Tasks;

namespace Library.Library.Cart.Commands.AddBookToCart
{
    public interface IAddBookToCartCommand
    {
        Task<CommandResult> ExecuteAsync(int bookId);
    }
}
