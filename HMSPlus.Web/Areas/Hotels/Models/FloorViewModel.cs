using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMSPlus.Web.Areas.Hotels.Models
{
    public class FloorFormViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter floor name")]
        public int Name { get; set; }

        public bool IsActive { get; set; }
    }

    public class FloorDisplayModel
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public int  TotalRooms { get; set; }

        public bool IsActive { get; set; }
    }
}