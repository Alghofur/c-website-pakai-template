using percobaanke8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace percobaanke8.Controllers
{
    [Authorize]
    public class MahasiswaController : Controller
    {
        public ActionResult Index()
        {
            {
                List<Mahasiswa> r;
                using (var s = new SIMEntities())
                {
                    r = s.Mahasiswa.ToList();
                }
                return View(r);
            }
  
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMEntities())
            {
                s.Mahasiswa.Add(model);
                s.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        
        [ActionName("Edit")]
        public ActionResult Edit_Get(string nim)
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMEntities())
            {
                model = s.Mahasiswa.Where(x => x.NIM == nim).FirstOrDefault();

            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(string nim)
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMEntities())
            {
                var m = s.Mahasiswa.Where(x => x.NIM == nim).FirstOrDefault();
                TryUpdateModel(m);
                s.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string nim)
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMEntities())
            {
                model = s.Mahasiswa.FirstOrDefault(x => x.NIM == nim);
            }
            return View(model);
        }

        [HttpGet]
        
        [ActionName("Delete")]
        public ActionResult Delete_Get(string nim)
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMEntities())
            {
                model = s.Mahasiswa.FirstOrDefault(x => x.NIM == nim);
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(string nim)
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMEntities())
            {
                var m = s.Mahasiswa.Remove(s.Mahasiswa.FirstOrDefault(x => x.NIM == nim));
                TryUpdateModel(m);
                s.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}