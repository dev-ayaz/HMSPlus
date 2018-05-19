namespace HMSPlus.DataAccess
{
    using HMSPlus.DataAccess.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Users.Roles")]
    public partial class Role
    {
    
        public string Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
