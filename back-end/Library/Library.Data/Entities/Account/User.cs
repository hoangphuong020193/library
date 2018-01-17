using Library.Common;
using Library.Data.Entities.Library;
using System;
using System.Collections.Generic;

namespace Library.Data.Entities.Account
{
    public partial class User : IBaseEntity
    {
        public User()
        {
            BookCart = new HashSet<BookCart>();
            BookFavorite = new HashSet<BookFavorite>();
            PermissionGroupMember = new HashSet<PermissionGroupMember>();
            UserBook = new HashSet<UserBook>();
            UserBookRequest = new HashSet<UserBookRequest>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SchoolEmail { get; set; }
        public string PersonalEmail { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? TitleId { get; set; }
        public DateTime? JoinDate { get; set; }
        public bool? Enabled { get; set; }

        public Title Title { get; set; }
        public ICollection<BookCart> BookCart { get; set; }
        public ICollection<BookFavorite> BookFavorite { get; set; }
        public ICollection<PermissionGroupMember> PermissionGroupMember { get; set; }
        public ICollection<UserBook> UserBook { get; set; }
        public ICollection<UserBookRequest> UserBookRequest { get; set; }
    }
}
