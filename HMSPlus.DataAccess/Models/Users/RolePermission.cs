namespace HMSPlus.DataAccess.Models.Users
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users.RolePermissions")]
    public partial class RolePermission
    {
        public int Id { get; set; }

        public int? MenuActionId { get; set; }

        [StringLength(128)]
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual MenuAction MenuAction { get; set; }
    }
}
