using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelResrvation.DAL.Model;
using HotelDB.Services.services;
namespace HotelReservationSystem.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            var data = _userService.GetUsers();
            return View(data);
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(UserInfo item)
        {
            UserInfo user = _userService.login(item.UserName,item.Password);
            if (user!=null)
            {
                //fetch user rights
                List<RoleANDRightTbl> roleANDRights = _userService.GetRoleANDRightTbls(user.UserType);

                //add list of user rights
                List<String> Rights = new List<string>();
                foreach(RoleANDRightTbl roleANDRight in roleANDRights)
                {
                    Rights.Add(roleANDRight.RightInfo.Name);
                }

                // store all right in session
                Session["Rights"] = Rights;

               return RedirectToAction("Home", "Index");

            }
            else
            return View();

        }



    }



}