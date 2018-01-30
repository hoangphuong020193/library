using HRM.CrossCutting.Command;
using Library.Library.Publishers.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Publishers.Commands.SavePublisher
{
    public interface ISavePublisherCommand
    {
        Task<CommandResult> ExecuteAsync(PublisherViewModel model);
    }
}
