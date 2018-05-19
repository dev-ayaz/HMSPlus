using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSPlus.DataAccess.Models.Hotels
{
    public class RoomPricing
    {
        public int Id { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public decimal Price { get; set; }

        public int RoomTypeId { get; set; }

        public virtual RoomType RoomType { get; set; }

    }
}
