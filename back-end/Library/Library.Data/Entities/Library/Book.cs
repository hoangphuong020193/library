using Library.Common;
using System;

namespace Library.Data.Entities.Library
{
    public partial class Book : IBaseEntity
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string BookCode { get; set; }
        public string BookName { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public byte[] BookImage { get; set; }
        public DateTime? DateImport { get; set; }
        public int? Amount { get; set; }
        public bool? Enabled { get; set; }

        public Category Category { get; set; }
    }
}
