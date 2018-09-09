using ASPClientSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPClientSchoolApp.Controllers
{
    public class FeeDueController : Controller
    {
        // GET: FeeDue
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            return View(GetAllFeeDue());
        }

        IEnumerable<FeeDueTable> GetAllFeeDue()
        {
            using (DBModel db = new DBModel())
            {
                return db.FeeDueTables.ToList<FeeDueTable>();
            }
        }

        //[HttpGet] iterator will be by default
        public ActionResult AddorEdit(int id = 0)
        {
            FeeDueTable emp = new FeeDueTable();
            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    emp = db.FeeDueTables.Where(x => x.FeeID == id).FirstOrDefault<FeeDueTable>();
                }
            }
            return View(emp);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddorEdit(FeeDueTable emp)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    if (emp.FeeID == 0)
                    {
                        db.FeeDueTables.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return RedirectToAction("Index");
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllFeeDue()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    FeeDueTable emp = db.FeeDueTables.Where(x => x.FeeID == id).FirstOrDefault<FeeDueTable>();
                    db.FeeDueTables.Remove(emp);
                    db.SaveChanges();

                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllFeeDue()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}