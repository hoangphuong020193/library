using HRM.CrossCutting.Command;
using Library.Library.Books.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Books.Commands.SaveBook
{
    public interface ISaveBookCommand
    {
        Task<CommandResult> ExecuteAsync(BookViewModel model);
    }
}
