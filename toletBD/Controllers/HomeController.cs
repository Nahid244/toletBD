using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using toletBDdb;
using toletBDdb.DBoperation;
using toletDb;

namespace toletBD.Controllers
{
    
    public class HomeController : Controller
    {
        AdminRep adminRep=null;
        UsersRep usersrep = null;
        public HomeController() {
            adminRep = new AdminRep();
            usersrep = new UsersRep();
        }
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult saveReg()
        {

            usersModel u = new usersModel()
            {
                users_id = Request["mail"],
                users_pass = Request["pass"],
                name = Request["user"],
                phone_no = "",
                addresss = ""

            };
            if ( Request["pass"] != Request["password"]  || usersrep.chkUser(Request["mail"])==true) {

                ModelState.AddModelError("name","fgfggggggggggggggggggggg");
                return RedirectToAction("Login", "Home");


            }
            if (ModelState.IsValid )
            {
                usersrep.addusers(u);
                return RedirectToAction("userAccount", "Home");
            }


           
            return Redirect(Request.UrlReferrer.PathAndQuery);


        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";


            return View();
        }
        public ActionResult Gett()
        {
            ViewBag.Message = "Your contact page.";
            var Res = adminRep.Getad();


            return View(Res);
        }
        public ActionResult meesage()
        {
           


            return View();
        }
        public ActionResult userAccount()
        {
            ///user account update



            return View();
        }
        public ActionResult Users()
        {
            ///user 
            
            return View();
        }
        public ActionResult postAd()
        {
            ///user 

            return View();
        }
        public ActionResult login()
        {
            ///user 

            return View();
        }
        

    }
}