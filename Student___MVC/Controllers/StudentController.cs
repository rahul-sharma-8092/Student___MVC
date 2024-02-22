using Student___MVC.DAL;
using Student___MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student___MVC.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL studentDAL = new StudentDAL();
        DataTable table = new DataTable();

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            //ddlCountryBind();
            return View();
        }

        [HttpPost]
        public ActionResult Register(Student student)
        {
            string res = studentDAL.StudentRegister(student);
            if (Convert.ToInt32(res) > 0)
            {
                return RedirectToAction("Student", student);
            }
            else
            {
                return View(student);
            }
        }

        #region ddlCountryBind
        private void ddlCountryBind()
        {
            table = studentDAL.CountryDdlBind();

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow item in table.Rows)
            {
                list.Add(new SelectListItem
                {
                    Text = item[""].ToString(),
                    Value = item[""].ToString()
                });
            }
            ViewBag.CountryList = list;
            table.Rows.Clear();
        }
        #endregion

        #region ddlCityyBind
        private void ddlCityyBind()
        {
            table = studentDAL.CityDdlBind();

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow item in table.Rows)
            {
                list.Add(new SelectListItem
                {
                    Text = item["City"].ToString(),
                    Value = item["CityId"].ToString()
                });
            }
            ViewBag.CityList = list;
            table.Rows.Clear();
        }
        #endregion
    }
}