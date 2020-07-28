using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPS.Models;

namespace IPS.Controllers
{
    public class UserController : Controller
    {
        Models.IPSEntities db = new Models.IPSEntities();
        // GET: User
       [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName,string Password)
        {
            
            int n = db.Userlogins.Where(u => u.UserName == UserName && u.Password == Password).Count();
            if (n >= 1)
            {
                Session["user"] =UserName;
                return Redirect("/Register/Test");
            }
            ViewBag.masg = "用户名或密码错误";
            return View();
            
        }
        public ActionResult Userlist()
        {
            List<Userlogin> userlist = db.Userlogins.ToList();

            return View(userlist);
        }
        public ActionResult Delete(int id)
        {
            db.Userlogins.Remove(db.Userlogins.Find(id));
            db.SaveChanges();

            return Redirect("/User/Userlist");
        }
       [HttpGet]
        public ActionResult Updata(int id)
        {
            Userlogin upuserlist = db.Userlogins.Find(id);
            List<SelectListItem> Istrole=new List<SelectListItem>();
            Istrole.Add(new SelectListItem
            {  Text = "-- 请选择角色--",Value = "0"});
              
                Istrole.Add(new SelectListItem{ Text ="普通用户",Value = "普通用户"});
            Istrole. Add(new SelectListItem
            {
                Text = "管理员",Value = "管理员" });
                    ViewBag.Istrole = Istrole;
            List<SelectListItem> Issatate = new List<SelectListItem>();
            Issatate.Add(new SelectListItem
            { Text = "-- 状态--", Value = "0" });

            Issatate.Add(new SelectListItem { Text = "正常", Value = "正常" });
            Issatate.Add(new SelectListItem
            {
                Text = "停用",
                Value = "停用"
            });
            ViewBag.Issatate = Issatate;
            return View(upuserlist);
        }
        public ActionResult Updata(Userlogin user)
        {
            if (ModelState.IsValid)
            {
            Userlogin upuserlist = db.Userlogins.Find(user.Id);
                upuserlist.UserName = user.UserName;
                upuserlist.Password = user.Password;
                upuserlist.Role = user.Role;
                upuserlist.State = user.State;
                int n = db.SaveChanges();
                if (n > 0)
                {
                    return Redirect("/User/Userlist");
                }
                
            }

            List<SelectListItem> Istrole = new List<SelectListItem>();
            Istrole.Add(new SelectListItem
            { Text = "-- 请选择角色--", Value = "0" });

            Istrole.Add(new SelectListItem { Text = "普通用户", Value = "普通用户" });
            Istrole.Add(new SelectListItem
            {
                Text = "管理员",
                Value = "管理员"
            });
            ViewBag.Istrole = Istrole;
            List<SelectListItem> Issatate = new List<SelectListItem>();
            Issatate.Add(new SelectListItem
            { Text = "-- 状态--", Value = "0" });

            Issatate.Add(new SelectListItem { Text = "正常", Value = "正常" });
            Issatate.Add(new SelectListItem
            {
                Text = "停用",
                Value = "停用"
            });
            ViewBag.Issatate = Issatate;
            return View(user);


        }
       
        public ActionResult Index()
        {
           

            return View();
        }
    }
}