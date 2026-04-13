using Microsoft.AspNetCore.Mvc;
using OAuth2_OIDC_WEB.Models.Entity;
using System.ComponentModel;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace OAuth2_OIDC_WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly OauthOidcsystemContext _context;

        public AccountController(ILogger<AccountController> logger, OauthOidcsystemContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        //ĐĂNG NHẬP BẰNG TÀI KHOẢN
        [HttpPost]
        public async Task<IActionResult> Login(string TenDangNhap, string MatKhau)
        {

            var passHash = _context.TaiKhoanNoiBos.Where(t => t.Username == TenDangNhap).Select(t => t.PassHash).FirstOrDefault();

            if (passHash != null && BCrypt.Net.BCrypt.Verify(MatKhau, passHash) == true)
                return Redirect("/Home/Index");

            ViewBag.Message = "Sai tài khoản hoặc mật khẩu";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //ĐĂNG KÝ TÀI KHOẢN
        //===================Chưa kiểm tra ràng buộc mật khảu : độ dài, ký tự đặc biệt, hoa thường
        //===================email - username : duy nhất, fomat (email phải có @)
        [HttpPost]
        public async Task<IActionResult> Register(string TenDangNhap, string MatKhau, string Email, string HoTen)
        {
            UserInfo u = new UserInfo();
            u.HoTen = HoTen;
            u.Email = Email;
            u.NgayTao = DateTime.Now;

            _context.UserInfos.Add(u);
            await _context.SaveChangesAsync();

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(MatKhau, salt);
            var userID = _context.UserInfos.Where(t => t.Email == Email).Select(t => t.Id).FirstOrDefault();

            TaiKhoanNoiBo tk = new TaiKhoanNoiBo();
            tk.Username = TenDangNhap;
            tk.PassHash = hash;
            tk.IdNguoiDung = userID;

            _context.TaiKhoanNoiBos.Add(tk);
            await _context.SaveChangesAsync();

            return Redirect("/Account/Login");
        }
    }
}
