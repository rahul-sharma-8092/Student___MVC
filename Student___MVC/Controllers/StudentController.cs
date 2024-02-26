using Newtonsoft.Json;
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
            ddlCountryBind();
            return View();
        }

        [HttpPost]
        public ActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                string res = studentDAL.StudentRegister(student);
                if (res != null)
                {
                    return RedirectToAction("Students");
                }
                else
                {
                    ddlCountryBind();
                    return View(student);
                }
            }
            else
            {
                ddlCountryBind();
                return View(student);
            }
        }

        [HttpGet]
        public ActionResult Students()
        {
            Student student = new Student();

            //int pageIndex = 1;
            //int pageSize = 10;

            table = studentDAL.StudentList();

            List<Student> list = new List<Student>();
            foreach (DataRow item in table.Rows)
            {
                list.Add(new Student
                {
                    StuId = Convert.ToInt32(item["Id"]),
                    Name = item["Name"].ToString(),
                    Email = item["Email"].ToString(),
                    Password = studentDAL.Decryption(item["Password"].ToString()),
                    BirthDate = Convert.ToDateTime(item["BirthDate"]),
                    Mobile = item["Mobile"].ToString(),
                    Address = item["Address"].ToString(),
                    Country = item["CountryName"].ToString(),
                    State = item["StateName"].ToString(),
                    District = item["DistrictName"].ToString(),
                    DpImageName = item["DpImage"].ToString(),
                    CertificateName = item["Certificate"].ToString(),
                });
                student.StudentList = list;

                //int totalRows = Convert.ToInt32(table.Rows[0]["TotalRows"]);
            }
            return View(student);
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
                    Text = item["CountryName"].ToString(),
                    Value = item["CountryId"].ToString()
                });
            }
            ViewBag.CountryList = list;
            table.Rows.Clear();
        }
        #endregion

        #region ddlStateBind
        [HttpPost]
        public string ddlStateBind(string id)
        {
            table = studentDAL.StateDdlBind(id);

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow item in table.Rows)
            {
                list.Add(new SelectListItem
                {
                    Text = item["StateName"].ToString(),
                    Value = item["StateId"].ToString()
                });
            }
            //ViewBag.StateList = list;
            string jsonRes = JsonConvert.SerializeObject(list);
            table.Rows.Clear();

            return jsonRes;
        }
        #endregion

        #region ddlDistrictBind
        [HttpPost]
        public string ddlDistrictBind(string id)
        {
            table = studentDAL.DistrictDdlBind(id);

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow item in table.Rows)
            {
                list.Add(new SelectListItem
                {
                    Text = item["DistrictName"].ToString(),
                    Value = item["DistrictId"].ToString()
                });
            }
            //ViewBag.StateList = list;
            string jsonRes = JsonConvert.SerializeObject(list);
            table.Rows.Clear();

            return jsonRes;
        }
        #endregion
    }
}