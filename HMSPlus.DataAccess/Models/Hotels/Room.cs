using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSPlus.DataAccess.Models.Hotels
{
    [Table("Hotel.Rooms")]
    public class Room
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }

        [StringLength(250)]
        public string RoomName { get; set; }

        public int? FloorId { get; set; }

        public virtual Floor Floor { get; set; }        

        public int? RoomTypeId { get; set; }

        public virtual RoomType RoomType { get;set;}

        public bool IsActive { get; set; }
    }
}
