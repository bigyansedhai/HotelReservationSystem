using HotelDB.Services.services;
using HotelResrvation.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationSystem.Controllers
{
    public class BranchController : Controller
    {
        private IBranchService _branchService;
        private IHotelService _hotelService;

        public BranchController(IBranchService branchService,IHotelService hotelService)
        {
            _branchService = branchService;
            _hotelService = hotelService;
        }
        // GET: Branch
        [HttpGet]
        [Route("Branch/Index")]
        public ActionResult Index()
        {
            var dt = _branchService.GetBraches();
            return View(dt);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            List<HotelStatu> hotels = _hotelService.GetHotels();
            ViewData["HotelId"] = new SelectList(hotels, "HotelId", "HotelName");
            return View();
            
            
        }
      
    }
}