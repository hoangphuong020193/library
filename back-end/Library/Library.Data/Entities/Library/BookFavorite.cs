using Library.Common;
using Library.Data.Entities.Account;

namespace Library.Data.Entities.Library
{
    public partial class BookFavorite : IBaseEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}
