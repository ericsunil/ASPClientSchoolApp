﻿using ASPClientSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPClientSchoolApp.Controllers
{
    public class PersonnelController : Controller
    {
        // GET: Personnel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllPersonnel());
        }

        IEnumerable<PersonnelTable> GetAllPersonnel()
        {
            using (DBModel db = new DBModel())
            {
                return db.PersonnelTables.ToList<PersonnelTable>();
            }
        }
        //[HttpGet] iterator will be by default
        public ActionResult AddorEdit(int id = 0)
        {
            PersonnelTable emp = new PersonnelTable();
            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    emp = db.PersonnelTables.Where(x => x.PersonnelID == id).FirstOrDefault<PersonnelTable>();
                }
            }
            return View(emp);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddorEdit(PersonnelTable emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    String fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    String extension = Path.GetFileName(emp.ImageUpload.FileName);
                    fileName = "IMG" + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/Personnel/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/Personnel/"), fileName));
                }
                using (DBModel db = new DBModel())
                {
                    if (emp.PersonnelID == 0)
                    {
                        db.PersonnelTables.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return RedirectToAction("Index");
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllPersonnel()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
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
                    PersonnelTable emp = db.PersonnelTables.Where(x => x.PersonnelID == id).FirstOrDefault<PersonnelTable>();
                    db.PersonnelTables.Remove(emp);
                    db.SaveChanges();

                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllPersonnel()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}