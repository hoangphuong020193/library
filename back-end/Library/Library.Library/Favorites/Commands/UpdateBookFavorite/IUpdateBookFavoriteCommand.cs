using System.Threading.Tasks;

namespace Library.Library.Favorites.Commands.UpdateBookFavorite
{
    public interface IUpdateBookFavoriteCommand
    {
        Task<bool> ExecuteAsync(int bookId);
    }
}
