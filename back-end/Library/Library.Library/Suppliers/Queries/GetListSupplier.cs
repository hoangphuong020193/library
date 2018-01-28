using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Suppliers.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Suppliers.Queries
{
    public class GetListSupplier : IGetListSupplier
    {
        private readonly IRepository<Supplier> _supplierRepository;

        public GetListSupplier(IRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<List<SupplierViewModel>> ExecuteAsync()
        {
            var result = await _supplierRepository.TableNoTracking.Select(x => new SupplierViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email,
                Enabled = x.Enabled.Value
            }).ToListAsync();

            return result;
        }
    }
}
