using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPS.Models;

namespace IPS.Areas.Nose.Controllers
{
    public class NoseindexController : Controller
    {
        // GET: Nose/Noseindex
        IPS.Models.IPSEntities db = new Models.IPSEntities();
        public ActionResult Index()
        {

            List<Info> infos = db.Infoes.Where(i => i.InfoId == 3).OrderByDescending(i => i.Id).Take(2).ToList();
            ViewBag.infos = infos;
            return View();
        }
        public ActionResult Detail( int id )
        {
            Info info = db.Infoes.Find(id);
           

           ViewData.Model = info;
            return View();

        }
        public ActionResult More(int t)
        {
            
            List<Info> infos = db.Infoes.Where(i => i.InfoId ==t).OrderByDescending(i => i.Id).ToList();

            ViewBag.infos = infos;
            return View();

        }
    }
}