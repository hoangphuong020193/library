using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRM.CrossCutting.Command;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Suppliers.ViewModels;

namespace Library.Library.Suppliers.Commands.SaveSupplier
{
    public class SaveSupplierCommand : ISaveSupplierCommand
    {
        private readonly IRepository<Supplier> _supplierRepository;

        public SaveSupplierCommand(IRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public Task<CommandResult> ExecuteAsync(SupplierViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
