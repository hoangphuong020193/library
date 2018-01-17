using Library.Common;
using Library.Data.Entities.Account;
using System;
using System.Collections.Generic;

namespace Library.Data.Entities.Library
{
    public partial class UserBookRequest : IBaseEntity
    {
        public UserBookRequest()
        {
            UserBook = new HashSet<UserBook>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string RequestCode { get; set; }
        public DateTime RequestDate { get; set; }

        public User User { get; set; }
        public ICollection<UserBook> UserBook { get; set; }
    }
}
