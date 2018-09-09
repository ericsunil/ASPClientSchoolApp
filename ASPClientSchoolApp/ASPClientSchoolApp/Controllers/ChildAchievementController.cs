using ASPClientSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPClientSchoolApp.Controllers
{
    public class ChildAchievementController : Controller
    {
        // GET: ChildAchivement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllChildAchievement());
        }

        IEnumerable<ChildAchievementTable> GetAllChildAchievement()
        {
            using (DBModel db = new DBModel())
            {
                return db.ChildAchievementTables.ToList<ChildAchievementTable>();
            }
        }

        //[HttpGet] iterator will be by default
        public ActionResult AddorEdit(int id = 0)
        {
            ChildAchievementTable emp = new ChildAchievementTable();
            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    emp = db.ChildAchievementTables.Where(x => x.ChildAchievementID == id).FirstOrDefault<ChildAchievementTable>();
                }
            }
            return View(emp);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddorEdit(ChildAchievementTable emp)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    if (emp.ChildAchievementID == 0)
                    {
                        db.ChildAchievementTables.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return RedirectToAction("Index");
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllChildAchivement()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
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
                    ChildAchievementTable emp = db.ChildAchievementTables.Where(x => x.ChildAchievementID == id).FirstOrDefault<ChildAchievementTable>();
                    db.ChildAchievementTables.Remove(emp);
                    db.SaveChanges();

                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllChildAchievement()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}