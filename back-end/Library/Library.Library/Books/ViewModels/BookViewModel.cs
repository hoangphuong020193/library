using System;

namespace Library.Library.Books.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BookName { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public byte[] BookImage { get; set; }
        public DateTime DateImport { get; set; }
        public int Amount { get; set; }
        public bool Enabled { get; set; }
    }
}
