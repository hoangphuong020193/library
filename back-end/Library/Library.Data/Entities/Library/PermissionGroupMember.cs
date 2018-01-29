using Library.Common;
using Library.Data.Entities.Account;

namespace Library.Data.Entities.Library
{
    public partial class PermissionGroupMember : IBaseEntity
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? UserId { get; set; }
        public bool? Enabled { get; set; }

        public PermissionGroup Group { get; set; }
        public User User { get; set; }
    }
}
