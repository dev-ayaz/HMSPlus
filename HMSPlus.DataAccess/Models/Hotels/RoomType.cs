using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSPlus.DataAccess.Models.Hotels
{
    [Table("Hotel.RoomTypes")]
    public class RoomType
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string NameEn { get; set; }

        [StringLength(250)]
        public string NameAr { get; set; }

        public int NumberOfBeds { get; set; }

        public bool IsActive { get; set; }

        public int? HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
