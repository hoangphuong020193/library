using HRM.CrossCutting.Command;
using Library.Library.Suppliers.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Suppliers.Commands.SaveSupplier
{
    public interface ISaveSupplierCommand
    {
        Task<CommandResult> ExecuteAsync(SupplierViewModel model);
    }
}
