using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPS.Models;
using Webdiyer.WebControls.Mvc;

namespace IPS.Controllers
{
    public class InfoController : Controller
    {
        Models.IPSEntities db = new Models.IPSEntities();
        // GET: Info
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Infolist(int id = 1)
        {
            PagedList<Info> infolist = db.Infoes.OrderByDescending(u => u.Id).ToPagedList(id, 3);
            ViewData.Model = infolist;
            return View(infolist);

        }
        [HttpGet]
        public ActionResult Addinfo()
        {
            List <SelectListItem> Isttypes = new List<SelectListItem>();
            List <InfoCategory> types = db.InfoCategories.OrderBy(t => t.InfoName).ToList();
            for (int i = 0; i < types.Count; i++)
            {
                Isttypes.Add(new SelectListItem(){Text = types[i].InfoName.ToString(), Value = types[i].Id.ToString() }) ;
        }
            ViewBag.Isttypes = Isttypes;

                return View();
        }


        [HttpPost]
        public ActionResult Addinfo(Info info)
        {
            
            
             db.Infoes.Add(info);
            db.SaveChanges();
            
          

           

        return RedirectToAction("Infolist");


           

        }
        public ActionResult Delete(int id)
        {
            db.Infoes.Remove(db.Infoes.Find(id));
            db.SaveChanges();

            return Redirect("/Info/Infolist");
        }
        [HttpGet]
        public ActionResult Updata(int id)
        {
            Info infolist = db.Infoes.Find(id);
            List<SelectListItem> Isttypes = new List<SelectListItem>();
            List<InfoCategory> types = db.InfoCategories.OrderBy(t => t.InfoName).ToList();
            for (int i = 0; i < types.Count; i++)
            {
                Isttypes.Add(new SelectListItem() { Text = types[i].InfoName.ToString(), Value = types[i].Id.ToString() });
            }
            ViewBag.Isttypes = Isttypes;
            return View(infolist);
        }
        [HttpPost]
        public ActionResult Updata(Info info)
        {
            if (ModelState.IsValid)
            {
                Info infolist = db.Infoes.Find(info.Id);
                infolist.Title = info.Title;
                infolist.infoContent = info.infoContent;
                infolist.InfoId = info.InfoId;

                int n = db.SaveChanges();
                if (n > 0)
                {
                    return Redirect("/Info/Infolist");
                }

            }

          
            List<SelectListItem> Isttypes = new List<SelectListItem>();
            List<InfoCategory> types = db.InfoCategories.OrderBy(t => t.InfoName).ToList();
            for (int i = 0; i < types.Count; i++)
            {
                Isttypes.Add(new SelectListItem() { Text = types[i].InfoName.ToString(), Value = types[i].Id.ToString() });
            }
            ViewBag.Isttypes = Isttypes;

            return View(info);


        }


    }
}