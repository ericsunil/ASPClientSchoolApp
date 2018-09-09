using ASPClientSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPClientSchoolApp.Controllers
{
    public class SchoolSubjectController : Controller
    {
        // GET: SchoolSubject
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllSchoolSubject());
        }

        IEnumerable<SchoolSubjectSetting> GetAllSchoolSubject()
        {
            using (DBModel db = new DBModel())
            {
                return db.SchoolSubjectSettings.ToList<SchoolSubjectSetting>();
            }
        }

        //[HttpGet] iterator will be by default
        public ActionResult AddorEdit(int id = 0)
        {
            SchoolSubjectSetting emp = new SchoolSubjectSetting();
            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    emp = db.SchoolSubjectSettings.Where(x => x.SchoolSubjectSettingID == id).FirstOrDefault<SchoolSubjectSetting>();
                }
            }
            return View(emp);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddorEdit(SchoolSubjectSetting emp)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    if (emp.SchoolSubjectSettingID == 0)
                    {
                        db.SchoolSubjectSettings.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return RedirectToAction("Index");
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllSchoolSubject()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
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
                    SchoolSubjectSetting emp = db.SchoolSubjectSettings.Where(x => x.SchoolSubjectSettingID == id).FirstOrDefault<SchoolSubjectSetting>();
                    db.SchoolSubjectSettings.Remove(emp);
                    db.SaveChanges();

                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllSchoolSubject()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}