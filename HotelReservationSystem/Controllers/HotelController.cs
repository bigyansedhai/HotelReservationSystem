using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelDB.Services.services;
using HotelResrvation.DAL.Model;

namespace HotelReservationSystem.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        //public HotelController()
        //{

        //}

        private IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }


        [HttpGet]
        [Route("Hotel/Index")]
        public ActionResult Index()
        {
            var data = (_hotelService.GetHotels());
            return View(data);
                //Json(new { hotellist = data }, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Bigyan()
        //{
        //  ViewBag.Massage ="This is Branch List Of Hotel Portfolia";
        //   List<BranchTbl> ist = new List<BranchTbl>();

        //using (HotelDBEntities2 _hotelDBEntities2 = new HotelDBEntities2())
        //{
        //   ist = _hotelDBEntities2.BranchTbls.ToList();
        //}
        //return View(ist);
        //}
        [HttpGet]
        public ActionResult insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(HotelStatu item)
        {
            bool result = _hotelService.insert(item);
            if (result)
                return RedirectToAction("Index");
            else
            {
               
                return View();

            }
        }
    }
   
}