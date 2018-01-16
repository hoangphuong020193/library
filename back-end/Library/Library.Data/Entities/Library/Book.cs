using Library.Common;
using System;
using System.Collections.Generic;

namespace Library.Data.Entities.Library
{
    public partial class Book : IBaseEntity
    {
        public Book()
        {
            BookCart = new HashSet<BookCart>();
            BookFavorite = new HashSet<BookFavorite>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string BookCode { get; set; }
        public string BookName { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public byte[] BookImage { get; set; }
        public DateTime? DateImport { get; set; }
        public int? Amount { get; set; }
        public int? AmountAvailable { get; set; }
        public string Author { get; set; }
        public int? PublisherId { get; set; }
        public int? SupplierId { get; set; }
        public string Size { get; set; }
        public string Format { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int? Pages { get; set; }
        public bool? Enabled { get; set; }
        public int MaximumDateBorrow { get; set; }

        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<BookCart> BookCart { get; set; }
        public ICollection<BookFavorite> BookFavorite { get; set; }
    }
}
