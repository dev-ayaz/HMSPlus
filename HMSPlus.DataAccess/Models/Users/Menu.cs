namespace HMSPlus.DataAccess.Models.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Users.Menus")]
    public partial class Menu
    {
        public Menu()
        {
            MenuActions = new HashSet<MenuAction>();
            SubMenus = new HashSet<Menu>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string JsFunction { get; set; }

        public string Icon { get; set; }

        public bool IsSidebarMenu { get; set; }

        public string MenuKey { get; set; }

        public int? ParentId { get; set; }

        public int? DisplayOrder { get; set; }

        public virtual ICollection<MenuAction> MenuActions { get; set; }

        [ForeignKey("ParentId")]
        public virtual ICollection<Menu> SubMenus { get; set; }

        public virtual Menu Menus { get; set; }
    }
}
