using HMSPlus.DataAccess.Models.Configurations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSPlus.DataAccess.Models.Hotels
{
    [Table("Hotel.Hotels")]
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(250)]
        public string BranchCode { get; set; }

        public string Description { get; set; }

        public int HotelTypeId { get; set; }

        [StringLength(250)]
        public string Location { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public int NumberOfFloors { get; set; }

        public int NumberOfRooms { get; set; }

        public DateTime?DateCreated { get; set; }

        public virtual HotelType HotelType {get;set;}

        public virtual City City { get; set; }

        public bool IsActive { get; set; }

    }
}
