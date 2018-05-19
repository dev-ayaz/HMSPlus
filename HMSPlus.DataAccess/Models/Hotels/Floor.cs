using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSPlus.DataAccess.Models.Hotels
{
    [Table("Hotel.Floors")]
    public class Floor
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? HotelId { get; set; }

        public virtual Hotel  Hotel { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
