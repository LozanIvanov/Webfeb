using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB.Database.Models;
using Webfeb.Models.Site.Account;

namespace Webfeb.Controllers.Site
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
            public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Site/Account/Login.cshtml");
        }
        [Route("login")]
        [HttpPost]
        public async Task< IActionResult> Login(string username,string password)
        {
            var result = await signInManager.PasswordSignInAsync(username, password, true, false);
            if(result.Succeeded==false)
            {
                return Redirect("/login");
            }
            var user=await userManager.FindByNameAsync(username);
            var roles = await userManager.GetRolesAsync(user);
            if(roles.Contains("Admin"))//да ме логне като админ
            {
                return Redirect("/Admin/DashBoard");
            }
            return Redirect("/");
        }
        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Site/Account/Register.cshtml");
        }
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult>Register(RegisterViewModel model)
        {
            var User = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
            };
           var result= await userManager.CreateAsync(User,model.Password);
            return RedirectToAction("Login");
        }
        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult>Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/login");
        }
        /*
         * public async<Task>Logout()
         * {
         * await.singInManager.SingOutAsync();]return redirect("/login");
         * }
         * private SingInManager<user>singInManager;
         * private UserManager<user>userManager;
         * [httpGet]
         * [Route("login");
        public IActionResult Login()
        {
        return view("~/Views/Site/Account/login.cshtml")
        }
         * [httpPost]
         * [Route("login");
        public asinc Task<IActionResult> Login(string user, string password)
        {
        var res=await userManager.PasswordAcync(user,password,true,false);
        if(result.Succssed=false)
        {
        return Redirect("/login");
        }
        var user =await usermanager.findbynameacync(user)
        vare role=await usermanager.getroleAcync(user)
        if(role.containt("admin)
        {
        return redirect(/Admin/DashBoard);
        }
        return redirect("/")
        }
          [httpGet]
         [Route("register");
        public IActionResult Register()
        {
        return view("~/Views/Site/Account/Register.cshtml")
        }
         [httppost]
         [Route("register");
        public await Task< IActionResult> Register(registerviewmodel)
        {
           var User-new User()
        {
        User=model.Username,
        Email=model.Email
        }
          var result=await SingInManager.CreateAsync(user,model.password);
        return RedirecttoAction("/login");
         */
    }
}
