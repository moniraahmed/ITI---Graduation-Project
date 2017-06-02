using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITIEscalationSystem.Controllers
{
    public class SupervisorController : Controller
    {
        // GET: Supervisor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCompliants()
        {
            return View();
        }
        public ActionResult ShowComplaintsDetails()
        {
            return View();
        }

    }
}