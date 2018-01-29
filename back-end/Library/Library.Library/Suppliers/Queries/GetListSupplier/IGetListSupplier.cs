using Library.Library.Suppliers.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Library.Suppliers.Queries.GetListSupplier
{
    public interface IGetListSupplier
    {
        Task<List<SupplierViewModel>> ExecuteAsync();
    }
}
