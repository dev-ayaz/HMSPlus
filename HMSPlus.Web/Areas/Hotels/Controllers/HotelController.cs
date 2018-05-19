using HMSPlus.DataAccess.Contracts;
using HMSPlus.DataAccess.Models.Hotels;
using HMSPlus.Web.Areas.Hotels.Models;
using HMSPlus.Web.Controllers;
using HMSPlus.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMSPlus.Web.Areas.Hotels.Controllers
{
    public class HotelController : BaseController
    {
        public HotelController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        // GET: Hotel/Hotel
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult HotelsList(SearchFilter filter)
        {

            var total = UnitOfWork.Hotels.Count();

            var pageNumber = filter.PageLenght > 0 ? (filter.Start / filter.PageLenght) + 1 : 1;

            IOrderedQueryable<Hotel> OrderByExpression(IQueryable<Hotel> r) => r.OrderByDescending(u => u.Id);


            var hotelList = UnitOfWork.Hotels.GetAll(pageNumber, filter.PageLenght, null, OrderByExpression).Select(h => new HotelDisplayViewModel
            {
                Id = h.Id,
                Address = h.Address,
                BranchCode = h.BranchCode,
                Description = h.Description,
                IsActive = h.IsActive,
                Location = h.Location,
                Name = h.Name,
                NumberOfFloors = h.NumberOfFloors,
                NumberOfRooms = h.NumberOfRooms
            }).ToList();


            return Json(new
            {
                sEcho = filter.Draw,
                iTotalRecords = total,
                iTotalDisplayRecords = total,
                aaData = hotelList
            },
                JsonRequestBehavior.AllowGet);
        }



        public ActionResult Floors()
        {
            var Floors = UnitOfWork.Floors.GetAll();
            return View();
        }
    }
}