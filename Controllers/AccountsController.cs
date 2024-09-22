using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using S7.Data;
using S7.Models.ViewModels;

namespace S7.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountsController(ApplicationDbContext context,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber=model.Phone,
            };
            var result=await userManager.CreateAsync(user, model.Password);
            Console.WriteLine(result);
            if(result.Succeeded)
                return RedirectToAction(nameof(Login));
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,true);
            if (result.Succeeded)
            {
                return RedirectToAction("index", "Home");
            }
            return View(model);
        }
    }
}
