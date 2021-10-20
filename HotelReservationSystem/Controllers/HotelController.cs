using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using HotelDB.Services.services;
using HotelResrvation.DAL.Model;
using Newtonsoft.Json;
using PagedList.Mvc;
using PagedList;
using HotelResrvation.DAL.Repo;
using System.Data;

namespace HotelReservationSystem.Controllers
{
    public class HotelController : Controller
    {
   
        private IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string GetHotels()
        {
            var data = _hotelService.GetHotels().Select(n=>new HotelStatu
            {
                HotelId=n.HotelId,
                HotelName=n.HotelName,
                Hotellogo=string.IsNullOrEmpty(n.Hotellogo)?"": Url.Content(n.Hotellogo),
                STAR = n.STAR
            });
            string json = JsonConvert.SerializeObject(data);
            return json;
        }

        [HttpGet]
        public ActionResult insert()
        {
            return View();
        }


        [HttpPost]
        public ActionResult InsertHotel()
        {
            return PartialView("_insertHotel");
        }

       

        [HttpPost]
        public ActionResult Insert(HotelStatu item)
        {

            HttpPostedFileBase file = Request.Files["imagefile"];
            ViewBag.lst = _hotelService.GetHotels();
            if(ModelState.IsValid)
            {

                if (file != null)
                {
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string FileExtension = Path.GetExtension(file.FileName);
                    string savePath = "~/HotelPhoto/";
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                    file.SaveAs(Server.MapPath(Path.Combine(savePath, FileName)));
                    item.Hotellogo = ("~/HotelPhoto/" + FileName);
                }

                if (item.HotelId == 0)
                {
                    try
                    {
                        _hotelService.insert(item);
                        return Json("Sucess Saved", JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {

                        return Json(ex.Message, JsonRequestBehavior.AllowGet);
                    }
                  
                   
                }
                else
                {
                    try
                    {
                        _hotelService.Edit(item);
                        return Json("Hotel Successfully Updated!!", JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {
                        return Json("Error while updating hotel!!", JsonRequestBehavior.AllowGet);
                    }
                              
                }
            }
            else
            {
                return Json("Error while updating hotel!!", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            HotelStatu hotelStatu = _hotelService.GetHotel(id);
            return View("_insertHotel",hotelStatu);

        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            _hotelService.Delete(Id);
            return Json(Id);

        }
  
        public ActionResult GetDataForGetTable()
        {
            //List of Column shown in the Table (user for finding the name of column on Sorting)  
           // List<string> columns = new List<string> { "HotelId", "HotelName", "Hotellogo", "STAR" };
            //This is used by DataTables to ensure that the Ajax returns from server-side processing requests are drawn in sequence by DataTables  
            Int32 ajaxDraw = Convert.ToInt32(Request.Params["draw"]);
            //OffsetValue  
            Int32 OffsetValue = Convert.ToInt32(Request.Params["start"]);
            //No of Records shown per page  
            Int32 PagingSize = Convert.ToInt32(Request.Params["length"]);
            //Getting value from the seatch TextBox  
            string searchby = Request.Params["search[value]"];
            //Index of the Column on which Sorting needs to perform  
            string sortColumn = Request.Params["order[0][column]"];
            //Finding the column name from the list based upon the column Index  
            sortColumn = Request.Params["columns[" + sortColumn + "][data]"];
            //Sorting Direction  
            string sortDirection = Request.Params["order[0][dir]"];
            //Get the Data from the Database  
            HotelSP objDBLayer = new HotelSP();
            DataTable dt = objDBLayer.GetData(sortColumn, sortDirection, OffsetValue, PagingSize, searchby);
            Int32 recordTotal = 0;
            List<HotelStatu> peoples = new List<HotelStatu>();
            //Binding the Data from datatable to the List  

            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HotelStatu people = new HotelStatu();
                    people.HotelId = Convert.IsDBNull(dt.Rows[i]["HotelId"]) ? default(int) : Convert.ToInt32(dt.Rows[i]["HotelId"]);
                    people.HotelName = Convert.IsDBNull(dt.Rows[i]["HotelName"]) ? default(string) : Convert.ToString(dt.Rows[i]["HotelName"]);
                    people.Hotellogo = Convert.IsDBNull(dt.Rows[i]["Hotellogo"]) ? default(string) : Url.Content("" + dt.Rows[i]["Hotellogo"].ToString());
                    people.STAR = Convert.IsDBNull(dt.Rows[i]["Star"]) ? default(string) : Convert.ToString(dt.Rows[i]["Star"]);
                    peoples.Add(people);
                }
                recordTotal = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["FilterTotalCount"]) : 0;
            }
            Int32 recordFiltered = recordTotal;
            DataTableResponse objDataTableResponse = new DataTableResponse()
            {
                draw = ajaxDraw,
                recordsFiltered = recordTotal,
                recordsTotal = recordTotal,
                data = peoples
            };

                return Json(objDataTableResponse, JsonRequestBehavior.AllowGet);
        }

    }
   
}