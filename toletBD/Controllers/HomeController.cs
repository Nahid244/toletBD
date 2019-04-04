using System;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using toletBDdb;
using toletBDdb.DBoperation;
using toletDb;
using System.Web.Security;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PagedList;
using PagedList.Mvc;
namespace toletBD.Controllers
{
    
    public class HomeController : Controller
    {
        AdminRep adminRep=null;
        AdRep adRep = null;
        UsersRep usersrep = null;
        InterestedRep interestedRep = null;
        GovernRep governRep = null;
        int val;
        public HomeController() {
            adminRep = new AdminRep();
            usersrep = new UsersRep();
            adRep = new AdRep();
            interestedRep = new InterestedRep();
            governRep = new GovernRep();
            val = 1;
        }
        
        public ActionResult Index(string searchby,string search, int ? page)
        {
            List<AdModel> a1;
            if (searchby == "Area" && search != null)
            {
                a1 = adRep.getsearchbyarea(search);
            }
            else if (searchby == "City" && search != null)
            {
                a1 = adRep.getsearchbycity(search);
            }

            else {
                a1 = adRep.get4Add();
            }
           
            

            return View(a1.ToPagedList(page ?? 1, 6));
           
            
        }
       


        /* [HttpPost]
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
                 return RedirectToAction("saveReg", "Home");


             }
             if (ModelState.IsValid )
             {
                 usersrep.addusers(u);
                 return RedirectToAction("userAccount", "Home");
             }



             return Redirect(Request.UrlReferrer.PathAndQuery);


         }
         */

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";


            return View();
        }
        public ActionResult Gett()
        {
            List<AdModel> a1 = adRep.getalAdd();


            return View(a1);
        }
        [Authorize]
        [HttpGet]
        public ActionResult meesage(string s)
        {
           


            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult meesage(int id)
        {



            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult userAccount()
        {
            ///user account update
            usersModel u = usersrep.get1user(User.Identity.Name);


            return View(u);
        }
       
        [HttpPost]
        public ActionResult userAccount(usersModel u1)
        {
            if (Request["npass"]=="" || Request["cnpass"]=="") {
                ModelState.AddModelError(String.Empty, "pass field can't be empty ");

            }
            if (Request["pass"] != usersrep.get1user(User.Identity.Name).users_pass || Request["npass"] != Request["cnpass"])
            {
                ModelState.AddModelError(String.Empty, "Wrong pass or pass doesn't match ");

            }

            if (Request["npass"] == "" || Request["cnpass"] == "" || Request["pass"] != usersrep.get1user(User.Identity.Name).users_pass || Request["npass"] != Request["cnpass"]) {
                u1 = usersrep.get1user(User.Identity.Name);
                return View(u1);
            }
            if (ModelState.IsValid) {
                usersrep.updateuser(User.Identity.Name,Request["user"],Request["pno"],Request["add"],Request["npass"]);
            }



            return Redirect("Index");
        }
        [Authorize]
        public ActionResult Users()
        {
            usersModel u1 = usersrep.get1user(User.Identity.Name);
           
            
            return View(u1);
        }
        [Authorize]
        [HttpGet]
        public ActionResult postAd()
        {
            ///user 

            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult postAd(AdModel a1, HttpPostedFileBase pic1, HttpPostedFileBase pic2, HttpPostedFileBase pic3, HttpPostedFileBase pic4)
        {
            if (pic1==null|| pic2 == null || pic3 == null || pic3 == null || Request["pno"]=="" || Request["city"]=="" || Request["area"] == "" || Request["streetname"] == ""|| Request["streerno"] == "") {
                ModelState.AddModelError(String.Empty, "image not selected or address not given");
                return View();

            }
            if (ModelState.IsValid)
            {
                String sddd=DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                if (pic1.ContentLength > 0)
                {
                   
                    var fileName =Path.GetFileName(pic1.FileName);
                   
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    pic1.SaveAs(path);
                }
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(pic1.InputStream))
                {
                    bytes = br.ReadBytes(pic1.ContentLength);
                }

                if (pic2.ContentLength > 0)
                {

                    var fileName = Path.GetFileName(pic2.FileName);

                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    pic2.SaveAs(path);
                }
                byte[] bytes1;
                using (BinaryReader br = new BinaryReader(pic2.InputStream))
                {
                    bytes1 = br.ReadBytes(pic2.ContentLength);
                }


                if (pic3.ContentLength > 0)
                {

                    var fileName = Path.GetFileName(pic3.FileName);

                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    pic3.SaveAs(path);
                }
                byte[] bytes2;
                using (BinaryReader br = new BinaryReader(pic3.InputStream))
                {
                    bytes2 = br.ReadBytes(pic3.ContentLength);
                }

                if (pic4.ContentLength > 0)
                {

                    var fileName = Path.GetFileName(pic4.FileName);

                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    pic4.SaveAs(path);
                }
                byte[] bytes3;
                using (BinaryReader br = new BinaryReader(pic4.InputStream))
                {
                    bytes3 = br.ReadBytes(pic4.ContentLength);
                }

                String s = sddd;

                Regex regexObj = new Regex(@"[^\d]");
             String   resultString = regexObj.Replace(s, "");
                String ass= User.Identity.Name.Replace(@"@gmail.com",@"");
                AdModel a = new AdModel()
               {
                ad_id =ass + resultString,
                users_id = User.Identity.Name,
                phone = Request["pno"],
                rent = Request["rent"],
                 img1 =bytes,
                 img2 = bytes1,
                 img3 = bytes2,
                 img4 = bytes3,


                


            datee = DateTime.Now ,



                availability = Request["availability"],






                city = Request["city"],
                area = Request["area"],
                street_name = Request["streetname"],
                street_no = Request["streetno"],
                additional_addresss = Request["additionaladdress"],



                number_of_room = Request["nofroom"],
                number_of_kitchen = Request["nofkitchen"],
                number_of_bathroom = Request["nofbathroom"],
                size_of_flat = Request["sizeflat"],
                additional_info = Request["additionalinfo"]

                };

           
                adRep.postad1(a);

            }
            
            return Redirect("Index");
        }
        [Authorize]
        public ActionResult delAd(String id,int ?page)
        {
            adRep.delAd(id);
           
            List<AdModel> a = adRep.getalAdd();
           
            return View("Index", a.ToPagedList(page ?? 1, 6));

            
        }
        [Authorize]
        [HttpGet]
        public ActionResult updateAd(String id )
        {
            String s = id;
            AdModel a = adRep.get1ad(s);

            return View(a);
        }
        [Authorize]
        [HttpPost]
        public ActionResult updateAd(String id,AdModel ab,int ? page)
        {

            AdModel a1 = new AdModel()
            {
                ad_id = id,
                users_id = User.Identity.Name,
                phone = Request["pno"],
                rent = Request["rent"],
               




               



                availability = Request["availability"],






                city = Request["city"],
                area = Request["area"],
                street_name = Request["streetname"],
                street_no = Request["streetno"],
                additional_addresss = Request["additionaladdress"],



                number_of_room = Request["nofroom"],
                number_of_kitchen = Request["nofkitchen"],
                number_of_bathroom = Request["nofbathroom"],
                size_of_flat = Request["sizeflat"],
                additional_info = Request["additionalinfo"]


            };
            adRep.updateAd(a1);
            
            List<AdModel> a = adRep.getalAdd();

            return View("Index",a.ToPagedList(page ?? 1,6));
        }
        [HttpGet]
        public ActionResult login()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult login(usersModel u1)
        {
            string s1 = Request["mail"].Replace("@gmail.com", "");
            if (usersrep.chkloginUser(s1, Request["pass"])!=true) {
                ModelState.AddModelError(String.Empty, "Invalid email or password");
                return View();
            }
            string s2 = Request["mail"].Replace("@gmail.com", "");
            FormsAuthentication.SetAuthCookie(s2,false);

            return Redirect("Index");

        }
        public ActionResult logout()
        {

            FormsAuthentication.SignOut();
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Reg()
        {
            ///user 

            return View();
        }
        [HttpPost]
        public ActionResult Reg(usersModel u1)
        {
            string s1 = Request["mail"].Replace("@gmail.com","");
            
            usersModel u = new usersModel()
            {
                users_id =s1,
                users_pass = Request["pass"],
                name = Request["user"],
                phone_no = "",
                addresss = ""

            };
            if (Request["user"]=="" || Request["pass"]=="" || Request["user"]== "" || Request["password"] == "" ) {
                ModelState.AddModelError(String.Empty, "Any of the fields can not be empty");

            }
            if (usersrep.chkUser(Request["mail"]) == true && Request["mail"]!="")
            {
                ModelState.AddModelError("users_id", "Email is taken");
            }
            if (Request["pass"] != Request["password"]) {
                ModelState.AddModelError("users_pass", "password doesn't match");
            }

            if (Request["pass"] != Request["password"] || usersrep.chkUser(Request["mail"]) == true || Request["user"] == "")
            {
                
               
                
                return View();


            }
            if (ModelState.IsValid)
            {
                usersrep.addusers(u);
               
            }


            return Redirect("Index");
        }
        [Authorize]
        [HttpGet]
        public ActionResult Respond(string id)
        {
            string s = User.Identity.Name;
            InterestedModel interestedModel = interestedRep.get1Respond(id,s);
            if (interestedModel==null) {
                InterestedModel i = new InterestedModel()
                {
                    ad_id = id,
                    familymembers = "",
                    name = "",
                    occupation = "",
                    phone = "",
                    presentAddress = "",
                    users_id = "",

                };
                return View(i);

            }
            return View(interestedModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Respond(InterestedModel interestedModel,string id)
        {
            if (Request["user"] == "" || Request["pno"] == "" || Request["occupation"] == "" || Request["fmembers"] == "" || Request["fmembers"] == "" || Request["paddress"] == "")
            {
                ModelState.AddModelError(String.Empty, "One or more Empty fields");
                InterestedModel interestedModel123 = interestedRep.get1Respond(id, User.Identity.Name);
                if (interestedModel123 == null)
                {
                    InterestedModel i = new InterestedModel()
                    {
                        ad_id = id,
                        familymembers = "",
                        name = "",
                        occupation = "",
                        phone = "",
                        presentAddress = "",
                        users_id = "",

                    };
                    return View(i);
                }
                    return View(interestedModel123);
            }
            else {
                InterestedModel interestedModel1 = new InterestedModel()
                {
                    users_id = User.Identity.Name,
                    ad_id=id,
                    name=Request["user"],
                    phone=Request["pno"],
                    occupation=Request["occupation"],
                    familymembers= Request["fmembers"],
                    presentAddress= Request["paddress"]

                };
                if (ModelState.IsValid) {
                    if (interestedRep.chkRespond(id, User.Identity.Name))
                    {
                        interestedRep.updateRespond(interestedModel1);

                    }
                    else {
                        interestedRep.addRespond(interestedModel1);

                    }
                    
                }
                InterestedModel interestedModel12 = interestedRep.get1Respond(id, User.Identity.Name);
                return View(interestedModel12);

            }

            
        }
        [Authorize]
       
        public ActionResult seeResponders(string id)
        {
            List<InterestedModel> interestedModel = interestedRep.getalResponder(id);

            return View(interestedModel);
        }
        [Authorize]
        public ActionResult delResponders(string id)
        {
            interestedRep.delRespond(id,User.Identity.Name);


            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult AdminPanel()
        {
            List<GovernModel> governModels = governRep.getalReq();

            return View(governModels);
           
        }
        [Authorize]
        [HttpGet]
        public ActionResult ReqAdminPanel()
        {


            return View();

        }
        [Authorize]
        [HttpPost]
        public ActionResult ReqAdminPanel(GovernModel governModel)
        {
            if (Request["msg"] == "") {
                ModelState.AddModelError(String.Empty, "Any of the fields can not be empty");
                return View();
            }
            else if (ModelState.IsValid) {
                GovernModel g = new GovernModel()
                {
                    users_id = User.Identity.Name,
                    request = Request["msg"]

                };
                governRep.addReq(g);
            }

            return RedirectToAction("Index");

        }
        public ActionResult delalReq()
        {
            governRep.clrReq();
            List<GovernModel> governModels = governRep.getalReq();

           
            return View("AdminPanel", governModels);
        }


    }
}