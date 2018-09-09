using ASPClientSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPClientSchoolApp.Controllers
{

    public class AnnouncementController : Controller
    {
        // GET: Announcement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllAnnouncement());
        }

        IEnumerable<AnnouncementTable> GetAllAnnouncement()
        {
            using (DBModel db = new DBModel())
            {
                return db.AnnouncementTables.ToList<AnnouncementTable>();
            }
        }
        public ActionResult AddorEdit(int id = 0)
        {
            AnnouncementTable emp = new AnnouncementTable();
            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    emp = db.AnnouncementTables.Where(x => x.AnnouncementID == id).FirstOrDefault<AnnouncementTable>();
                }
            }
            return View(emp);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddorEdit(AnnouncementTable emp)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    if (emp.AnnouncementID == 0)
                    {
                        db.AnnouncementTables.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return RedirectToAction("Index");
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllAnnouncement()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
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
                    AnnouncementTable emp = db.AnnouncementTables.Where(x => x.AnnouncementID == id).FirstOrDefault<AnnouncementTable>();
                    db.AnnouncementTables.Remove(emp);
                    db.SaveChanges();

                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllAnnouncement()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}