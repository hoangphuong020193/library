using Library.Common;
using System.Collections.Generic;

namespace Library.Data.Entities.Account
{
    public partial class Title : IBaseEntity
    {
        public Title()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool? Enabled { get; set; }

        public ICollection<User> User { get; set; }
    }
}
