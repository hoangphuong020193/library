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
            PermissionGroupMember = new HashSet<PermissionGroupMember>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
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
        public ICollection<PermissionGroupMember> PermissionGroupMember { get; set; }
    }
}
