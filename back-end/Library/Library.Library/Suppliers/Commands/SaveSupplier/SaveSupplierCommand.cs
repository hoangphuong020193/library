using System;
using System.Net;
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

        public async Task<CommandResult> ExecuteAsync(SupplierViewModel model)
        {
            try
            {
                if (!ValidationData(model))
                {
                    return CommandResult.Failed(new CommandResultError()
                    {
                        Code = (int)HttpStatusCode.NotAcceptable,
                        Description = "Data not correct"
                    });
                }

                if (model.Id != 0)
                {
                    var supplier = await _supplierRepository.GetByIdAsync(model.Id);
                    if (supplier == null)
                    {
                        return CommandResult.Failed(new CommandResultError()
                        {
                            Code = (int)HttpStatusCode.NotFound,
                            Description = "Data not found"
                        });
                    }

                    supplier.Name = model.Name;
                    supplier.Address = model.Address;
                    supplier.Phone = model.Phone;
                    supplier.Email = model.Email;
                    supplier.Enabled = model.Enabled;

                    await _supplierRepository.UpdateAsync(supplier);
                }
                else
                {
                    Supplier entity = new Supplier();
                    entity.Name = model.Name;
                    entity.Address = model.Address;
                    entity.Phone = model.Phone;
                    entity.Email = model.Email;

                    await _supplierRepository.InsertAsync(entity);
                    model.Id = entity.Id;
                }

                return CommandResult.SuccessWithData(model.Id);
            }
            catch (Exception ex)
            {
                return CommandResult.Failed(new CommandResultError()
                {
                    Code = (int)HttpStatusCode.InternalServerError,
                    Description = ex.Message
                });
            }
        }

        private bool ValidationData(SupplierViewModel model)
        {
            if (model == null || model.Name == null)
            {
                return false;
            }
            return true;
        }
    }
}
