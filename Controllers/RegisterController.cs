using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPS.Controllers
{
    public class RegisterController : Controller
    {
        Models.IPSEntities db = new Models.IPSEntities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
             string user = Session["user"].ToString();
            return View();
        }
        [HttpGet]
        public ActionResult Result()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Result(string UserName,string Password,string Role,string State)
        {
            
            int n = db.Userlogins.Where(u => u.UserName == UserName).Count();
            if (n >= 1)
            {
                ViewBag.masg = "此用户名已存在";

            }
            else
            {
               
                Models.Userlogin userlogin = new Models.Userlogin();
                userlogin.UserName = UserName;
                userlogin.Password = Password;
                userlogin.Role = "普通用户";
                userlogin.State = "正常";
                db.Userlogins.Add(userlogin);
                db.SaveChanges();
                ViewBag.masg = "注册成功";

            }
         

            return View();
        }

    }
}