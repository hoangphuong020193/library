using System.Threading.Tasks;

namespace Library.Library.Books.Queries.CheckBookExistsCode
{
    public interface ICheckBookCodeExistsQuery
    {
        Task<bool> ExecuteAsync(int bookId, string bookCode);
    }
}
