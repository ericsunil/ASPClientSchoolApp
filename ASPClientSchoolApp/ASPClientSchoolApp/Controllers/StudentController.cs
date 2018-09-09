using ASPClientSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPClientSchoolApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllStudent());
        }

        IEnumerable<StudentTable> GetAllStudent()
        {
            using (DBModel db = new DBModel())
            {
                return db.StudentTables.ToList<StudentTable>();
            }
        }
        //[HttpGet] iterator will be by default
        public ActionResult AddorEdit(int id = 0)
        {
            StudentTable emp = new StudentTable();
            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    emp = db.StudentTables.Where(x => x.StudentID == id).FirstOrDefault<StudentTable>();
                }
            }
            return View(emp);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddorEdit(StudentTable emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    String fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    String extension = Path.GetFileName(emp.ImageUpload.FileName);
                    fileName = "IMG" + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/Student/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/Student/"), fileName));
                }
                using (DBModel db = new DBModel())
                {
                    if (emp.StudentID == 0)
                    {
                        db.StudentTables.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return RedirectToAction("Index");
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllStudent()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
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
                    StudentTable emp = db.StudentTables.Where(x => x.StudentID == id).FirstOrDefault<StudentTable>();
                    db.StudentTables.Remove(emp);
                    db.SaveChanges();

                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllStudent()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}