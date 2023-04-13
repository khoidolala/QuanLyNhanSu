using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Security;

namespace QuanLyNhanSu.Controllers
{
    public class LoginNhanVienController : Controller
    {
        DBContext db = new DBContext();
        // GET: LoginNhanVien
        public ActionResult Login()
        {
            if (Request.Cookies["LoginCookie"] != null && !HttpContext.User.Identity.IsAuthenticated)
            {
                var username = Request.Cookies["LoginCookie"]["username"];
                var password = Request.Cookies["LoginCookie"]["password"];

                // Kiểm tra đăng nhập
                if (username!=null && password!=null)
                {
                    // Đăng nhập thành công
                    FormsAuthentication.SetAuthCookie(username, true);
                }
                else
                {
                    ViewBag.Error = "";
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection field, bool? rememberMe)
        {
            string strerror = "";
            string username = field["username"];
            string password = field["password"];
            /*string ps = EncodePass.GetMD5(password);*/
            tblUser rowuser = db.tblUsers.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            if (rowuser == null)
            {
                strerror = "Sai tên đăng nhập hoặc mật khẩu";
            }
            else
            {
                if (rememberMe.HasValue && rememberMe.Value)
                {
                    HttpCookie cookie = new HttpCookie("LoginCookie");
                    cookie.Values.Add("username", username);
                    cookie.Values.Add("password", password);
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookie);
                }
                if (rowuser.Quyen == 1)
                {
                    strerror = "Trang này không dành cho Admin, vui lòng đăng nhập lại!";

                }
                if (rowuser.Quyen == 2)
                {
                    Session["MaNV"] = rowuser.MaNV;
                    Session["TenNV"] = rowuser.TenNV;
                    return RedirectToAction("Index", "QLNhanVien");

                }
                else
                {
                    Session["MaNV"] = rowuser.MaNV;
                    Session["TenNV"] = rowuser.TenNV;
                    return RedirectToAction("Index", "NhanVien");
                }
            }

            ViewBag.Error = "<span class='text-danger'>" + strerror + "</span>";
            
            return View();
        }
        public ActionResult Logout()
        {
            Session["UserName"] = "";
            Session["IDUser"] = "";
            return RedirectToAction("Login", "LoginNhanVien");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string odlPassword, string newPassword, string comfirmPassword)
        {
            var id = Session["MaNV"] as string;
            var user = db.tblUsers.Find(id);
            Session["Password"] = user.Password;
            if (user == null)
            {
                return HttpNotFound();
            }
            if (user.Password != odlPassword)
            {
                ViewBag.Error = "Mật khẩu không khớp";
                return RedirectToAction("ChangePassword");
            }
            if(newPassword!=comfirmPassword)
            {
                ViewBag.Error1 = "Mật khẩu không khớp";
                return RedirectToAction("ChangePassword");
            }
            user.Password = newPassword;
            db.SaveChanges();
            return RedirectToAction("Login","LoginNhanVien");
        }
        public ActionResult ThongTinCaNhan()
        {
            var id = Session["MaNV"] as string;
            var ttcn = db.tblThongTinNVs.Where(x => x.MaNV == id).FirstOrDefault();
            return View(ttcn);
        }
    }
}