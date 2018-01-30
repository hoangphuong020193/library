using System;
using System.Net;
using System.Threading.Tasks;
using HRM.CrossCutting.Command;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Publishers.ViewModels;

namespace Library.Library.Publishers.Commands.SavePublisher
{
    public class SavePublisherCommand : ISavePublisherCommand
    {
        private readonly IRepository<Publisher> _publisherRepository;

        public SavePublisherCommand(IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<CommandResult> ExecuteAsync(PublisherViewModel model)
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
                    var supplier = await _publisherRepository.GetByIdAsync(model.Id);
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

                    await _publisherRepository.UpdateAsync(supplier);
                }
                else
                {
                    Publisher entity = new Publisher();
                    entity.Name = model.Name;
                    entity.Address = model.Address;
                    entity.Phone = model.Phone;
                    entity.Email = model.Email;

                    await _publisherRepository.InsertAsync(entity);
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

        private bool ValidationData(PublisherViewModel model)
        {
            if (model == null || model.Name == null)
            {
                return false;
            }
            return true;
        }
    }
}
