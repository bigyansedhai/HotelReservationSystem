using HotelDB.Services.services;
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

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        // GET: Branch
        [HttpGet]
        [Route("Branch/Index")]
        public ActionResult Index()
        {
            var dt = _branchService.GetBranches();
            return View(dt);
        }
    }
}