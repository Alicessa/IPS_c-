using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPS.Models;

namespace IPS.Controllers
{
    public class InfoCategoryController : Controller
    {
        Models.IPSEntities db = new Models.IPSEntities();
        // GET: InfoCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InfoCategorylist()
        {
            List<InfoCategory> infoCategories = db.InfoCategories.ToList();

            return View(infoCategories);
            
        }
        [HttpGet]
        public ActionResult AddInfoCategory()
        {

            List<SelectListItem> Istate = new List<SelectListItem>();
            Istate.Add(new SelectListItem
            { Text = "-- 状态--", Value = "0" });

            Istate.Add(new SelectListItem { Text = "正常", Value = "1" });
            Istate.Add(new SelectListItem
            {
                Text = "停用",
                Value = "0"
            });
            ViewBag.Istate = Istate;
            return View();
        }


        [HttpPost]
        public ActionResult AddInfoCategory(InfoCategory category)
        {

            int n = db.InfoCategories.Where(u => u.InfoCategory1 == category.InfoCategory1).Count();
            if (n >= 1)
            {
                ViewBag.masg = "此类别id已经存在";

            }
            else
            {
                db.InfoCategories.Add(category);
                db.SaveChanges();
            }

            return RedirectToAction("InfoCategorylist");




        }
        public ActionResult Delete(int id)
        {
            db.InfoCategories.Remove(db.InfoCategories.Find(id));
            db.SaveChanges();

            return RedirectToAction("InfoCategorylist");
        }
        [HttpGet]
        public ActionResult Updata(int id)
        {
            InfoCategory category = db.InfoCategories.Find(id);

            List<SelectListItem> Istate = new List<SelectListItem>();
            Istate.Add(new SelectListItem
            { Text = "-- 状态--", Value = "0" });

            Istate.Add(new SelectListItem { Text = "正常", Value = "1" });
            Istate.Add(new SelectListItem
            {
                Text = "停用",
                Value = "0"
            });
            ViewBag.Istate = Istate;
            return View(category);
        }
       
        public ActionResult Updata(InfoCategory category)
        {
            if (ModelState.IsValid)
            {
                InfoCategory categorylist = db.InfoCategories.Find(category.Id);
                categorylist.InfoName = category.InfoName;
                categorylist.InfoCategory1 = category.InfoCategory1;
              
                categorylist.State = category.State;
                int n = db.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("InfoCategorylist");
                }

            }


            List<SelectListItem> Istate = new List<SelectListItem>();
            Istate.Add(new SelectListItem
            { Text = "-- 状态--", Value = "0" });

            Istate.Add(new SelectListItem { Text = "正常", Value = "1" });
            Istate.Add(new SelectListItem
            {
                Text = "停用",
                Value = "0"
            });
            ViewBag.Istate = Istate;
           
            return View(category);


        }
    }
}