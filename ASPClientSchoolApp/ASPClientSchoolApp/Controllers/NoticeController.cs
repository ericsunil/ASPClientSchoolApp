using ASPClientSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPClientSchoolApp.Controllers
{
    public class NoticeController : Controller
    {
        // GET: Notice
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            return View(GetAllNotice());
        }

        IEnumerable<NoticeTable> GetAllNotice()
        {
            using (DBModel db = new DBModel())
            {
                return db.NoticeTables.ToList<NoticeTable>();
            }
        }

        //[HttpGet] iterator will be by default
        public ActionResult AddorEdit(int id = 0)
        {
            NoticeTable emp = new NoticeTable();
            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    emp = db.NoticeTables.Where(x => x.NoticeID == id).FirstOrDefault<NoticeTable>();
                }
            }
            return View(emp);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddorEdit(NoticeTable emp)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    if (emp.NoticeID == 0)
                    {
                        db.NoticeTables.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return RedirectToAction("Index");
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllNotice()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
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
                    NoticeTable emp = db.NoticeTables.Where(x => x.NoticeID == id).FirstOrDefault<NoticeTable>();
                    db.NoticeTables.Remove(emp);
                    db.SaveChanges();

                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllNotice()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}