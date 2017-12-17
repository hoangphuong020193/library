using Library.Common;
using System.Collections.Generic;

namespace Library.Data.Entities.Library
{
    public partial class PermissionGroup : IBaseEntity
    {
        public PermissionGroup()
        {
            PermissionGroupMember = new HashSet<PermissionGroupMember>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }
        public bool? Enabled { get; set; }

        public ICollection<PermissionGroupMember> PermissionGroupMember { get; set; }
    }
}
