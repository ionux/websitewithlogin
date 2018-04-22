using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebsiteWithLogin.ViewModels;
using WebsiteWithLogin.Models;
using Microsoft.AspNetCore.Identity;

namespace WebsiteWithLogin.Controllers
{
    public class StudentController : Controller
    {
        private UserManager<StudentUser> userManager;
        private SignInManager<StudentUser> signinManager;

        public StudentController(UserManager<StudentUser> userManager, SignInManager<StudentUser> signinManager)
        {
            this.userManager = userManager;
            this.signinManager = signinManager;
        }

        ///////////////////////////////////////////////////////////////
        ///////////////////////// Get methods /////////////////////////
        ///////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return View("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signinManager.SignOutAsync();

            return RedirectToAction("Index");
        }

        ///////////////////////////////////////////////////////////////
        ///////////////////////// Post methods ////////////////////////
        ///////////////////////////////////////////////////////////////

        [HttpPost]
        public async Task<IActionResult> Register(StudentRegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new StudentUser()
                {
                    UserName = vm.Email,
                    Email = vm.Email,
                };

                var result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    //await signinManager.SignInAsync(user, false);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            StudentUser user = await userManager.FindByEmailAsync(vm.Email);

            if (user != null)
            {
                var result = await signinManager.CheckPasswordSignInAsync(user, vm.Password, false);

                if (result.Succeeded)
                {
                    await signinManager.SignInAsync(user, false);
                }
            }

            return RedirectToAction("Index");
        }
    }
}