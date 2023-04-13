using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
namespace QuanLyNhanSu.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Admin/DashBoard
        public ActionResult Index()
        {
            int userCount = db.tblUsers.Count();
            ViewBag.UserCount = userCount;
            int employeeCount = db.tblThongTinNVs.Count();
            ViewBag.EmployeeCount = employeeCount;
            List<tblThongTinNV> nv = db.tblThongTinNVs.ToList();
            return View();
        }
    }
}