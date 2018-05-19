using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMSPlus.Web.Areas.Hotels.Models
{
    public class HotelFormViewModel
    {
        public HotelFormViewModel()
        {
            HotelTypes = new List<SelectListItem>();
            CitiesList = new List<SelectListItem>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter hotel name")]
        public string Name { get; set; }

        public string BranchCode { get; set; }

        public string Description { get; set; }

        public List<SelectListItem> HotelTypes { get; set; }

        [Required(ErrorMessage ="Please select hotel type")]
        public int HotelTypeId { get; set; }

        public string Location { get; set; }

        public List<SelectListItem> CitiesList { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        [Display(Name="Total Floors")]
        public int NumberOfFloors { get; set; }

        [Display(Name = "Total Rooms")]
        public int NumberOfRooms { get; set; }

        public bool IsActive { get; set; }

    }

    public class HotelDisplayViewModel 
    {
     [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter hotel name")]
    public string Name { get; set; }

    public string BranchCode { get; set; }

    public string Description { get; set; }

    public int HotelType { get; set; }

    public string Location { get; set; }

    public int CityName { get; set; }

    public string Address { get; set; }

    [Display(Name = "Total Floors")]
    public int NumberOfFloors { get; set; }

    [Display(Name = "Total Rooms")]
    public int NumberOfRooms { get; set; }

    public bool IsActive { get; set; }
}
}