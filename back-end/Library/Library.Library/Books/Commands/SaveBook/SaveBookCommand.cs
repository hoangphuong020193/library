using System;
using System.Net;
using System.Threading.Tasks;
using HRM.CrossCutting.Command;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Books.Queries.GetBookByBookCode;
using Library.Library.Books.ViewModels;

namespace Library.Library.Books.Commands.SaveBook
{
    public class SaveBookCommand : ISaveBookCommand
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IGetBookByBookCodeQuery _getBookByBookCodeQuery;

        public SaveBookCommand(
            IRepository<Book> bookRepository,
            IGetBookByBookCodeQuery getBookByBookCodeQuery)
        {
            _bookRepository = bookRepository;
            _getBookByBookCodeQuery = getBookByBookCodeQuery;
        }

        public async Task<CommandResult> ExecuteAsync(BookViewModel model)
        {
            try
            {
                if (model.BookId == 0)
                {
                    Book entity = new Book();
                    entity.Id = 0;
                    entity.CategoryId = model.CategoryId;
                    entity.BookCode = model.BookCode;
                    entity.BookName = model.BookName;
                    entity.Tag = model.Tag;
                    entity.Description = model.Description;
                    entity.DateImport = DateTime.Now;
                    entity.Amount = model.Amount;
                    entity.AmountAvailable = model.Amount;
                    entity.Author = model.Author;
                    entity.PublisherId = model.PublisherId;
                    entity.SupplierId = model.SupplierId;
                    entity.Size = model.Size;
                    entity.Format = model.Format;
                    entity.PublicationDate = model.PublicationDate;
                    entity.Pages = model.Pages;
                    entity.MaximumDateBorrow = model.MaximumDateBorrow;

                    await _bookRepository.InsertAsync(entity);
                }
                else
                {
                    Book entity = await _bookRepository.GetByIdAsync(model.BookId);
                    entity.CategoryId = model.CategoryId;
                    entity.BookCode = model.BookCode;
                    entity.BookName = model.BookName;
                    entity.Tag = model.Tag;
                    entity.Description = model.Description;
                    entity.Amount = model.Amount;
                    entity.Author = model.Author;
                    entity.PublisherId = model.PublisherId;
                    entity.SupplierId = model.SupplierId;
                    entity.Size = model.Size;
                    entity.Format = model.Format;
                    entity.PublicationDate = model.PublicationDate;
                    entity.Pages = model.Pages;
                    entity.MaximumDateBorrow = model.MaximumDateBorrow;

                    await _bookRepository.UpdateAsync(entity);
                }

                model = await _getBookByBookCodeQuery.ExecuteAsync(model.BookCode);
                return CommandResult.SuccessWithData(model);
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
    }
}
