using HRM.CrossCutting.Command;
using Library.Library.Categories.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Categories.Commands.SaveCategory
{
    public interface ISaveCategoryCommand
    {
        Task<CommandResult> ExecuteAsync(CategoryViewModel model);
    }
}
