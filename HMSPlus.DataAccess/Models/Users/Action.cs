namespace HMSPlus.DataAccess.Models.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Users.Actions")]
    public partial class Action
    {
        public Action()
        {
            MenuActions = new HashSet<MenuAction>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Key { get; set; }

        public virtual ICollection<MenuAction> MenuActions { get; set; }
    }
}
