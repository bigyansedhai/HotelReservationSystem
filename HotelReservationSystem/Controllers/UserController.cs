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
        [HttpPost]
        public ActionResult Login(UserInfo item)
        {
            UserInfo user= _userService.login(item.UserName,item.Password);
            if (user!=null)
            {
                //fetch user rights
                List<RoleANDRightTbl> roleANDRights = _userService.GetRoleANDRightTbls(user.UserType);

                //add list of user rights
                List<string> Rights = new List<string>();
                foreach(RoleANDRightTbl roleANDRight in roleANDRights)
                {
                    Rights.Add(roleANDRight.RightInfo.Name);
                }

                // store all right in session
                Session["Rights"] = Rights;

               return RedirectToAction("Index","Home");

            }
            else
            
                return View();

        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(UserInfo item)
        {
            //if (ModelState.IsValid == false)
            //{
                if(item.UserId >0)
                {
                    bool result = _userService.Edit(item);
                    if(result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    bool result = _userService.insert(item);
                    if (result)
                        return RedirectToAction("Index");
                    else
                    {
                        //List<UserRole> userRoles = _userService.getRo;
                        return View();

                    }
                }


            //}
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            UserInfo userInfo = _userService.GetUser(Id);
            return View("Insert", userInfo);
        }
        public ActionResult Delete(int Id)
        {
            _userService.Delete(Id);
            return RedirectToAction("Index");
        }



    }



}