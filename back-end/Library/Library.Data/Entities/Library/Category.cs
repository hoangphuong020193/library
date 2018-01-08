using Library.Common;
using System.Collections.Generic;

namespace Library.Data.Entities.Library
{
    public partial class Category : IBaseEntity
    {
        public Category()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool? Enabled { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
