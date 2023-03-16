using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyNhanSu.Areas.NhanVien.Controllers
{
    public class NVDangNhapController : Controller
    {
        DBContext db = new DBContext();
        // GET: NhanVien/NVDanNhap
        public ActionResult Login()
        {
            if (!Session["UserName"].Equals(""))
            {
                return RedirectToAction("Index", "QLTaiKhoan");
            }
            ViewBag.Error = "";
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection field)
        {
            string strerror = "";
            string username = field["username"];
            string password = field["password"];
            EncodePass.GetMD5(password);
            tblUser rowuser = db.tblUsers.Where(x => x.UserName.Contains(username) && x.Password == password).FirstOrDefault();
            if (rowuser == null)
            {
                strerror = "Sai tên đăng nhập hoặc mật khẩu";
            }
            else
            {
                if (rowuser.Quyen == 1)
                {
                    strerror = "trang này không dành cho Admin";

                }
                if (rowuser.Quyen == 2)
                 {

                    return RedirectToAction("Index", "QLNhanVien");
                }
                if (rowuser.Quyen == 3)
                {
                    return RedirectToAction("Index", "QLLuongs");
                }
                if (rowuser.Quyen == 4)
                {

                }
            }

            ViewBag.Error = "<span class='text-danger'>" + strerror + "</span>";
            return View();
        }
    }
}