using ASPClientSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPClientSchoolApp.Controllers
{
    public class RemarkController : Controller
    {
        // GET: Remark
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllRemark());
        }

        IEnumerable<RemarkTable> GetAllRemark()
        {
            using (DBModel db = new DBModel())
            {
                return db.RemarkTables.ToList<RemarkTable>();
            }
        }

        //[HttpGet] iterator will be by default
        public ActionResult AddorEdit(int id = 0)
        {
            RemarkTable emp = new RemarkTable();
            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    emp = db.RemarkTables.Where(x => x.RemarkID == id).FirstOrDefault<RemarkTable>();
                }
            }
            return View(emp);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddorEdit(RemarkTable emp)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    if (emp.RemarkID == 0)
                    {
                        db.RemarkTables.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return RedirectToAction("Index");
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllRemark()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
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
                    RemarkTable emp = db.RemarkTables.Where(x => x.RemarkID == id).FirstOrDefault<RemarkTable>();
                    db.RemarkTables.Remove(emp);
                    db.SaveChanges();

                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllRemark()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}