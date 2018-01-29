using Library.Common;
using Library.Data.Entities.Account;
using System;

namespace Library.Data.Entities.Library
{
    public partial class UserBook : IBaseEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RequestId { get; set; }
        public int? BookId { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Status { get; set; }

        public Book Book { get; set; }
        public UserBookRequest Request { get; set; }
        public User User { get; set; }
    }
}
