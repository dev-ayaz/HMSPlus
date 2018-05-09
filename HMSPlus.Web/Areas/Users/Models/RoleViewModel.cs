using System.ComponentModel.DataAnnotations;

namespace HMSPlus.Web.Areas.Users.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public string RoleDescription { get; set; }
    }
}