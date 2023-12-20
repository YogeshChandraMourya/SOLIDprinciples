using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOLIDDb_15_12_23_.Models;

namespace SOLIDDb_15_12_23_.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly SolidContext _solidContext;
        private readonly ILogger<UserController> _logger;
        private readonly IEmailService _emailService;


        public UserController(IUserService userService, SolidContext solidContext, ILogger<UserController> logger, IEmailService emailService)

        {
            _logger = logger;
            _userService = userService;
            _solidContext = solidContext;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _solidContext.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (_userService.RegisterUser(user))
            {
                return RedirectToAction("RegistrationSuccess");
            }
            else
            {
                ViewBag.ErrorMessage = "Registration failed. Please provide valid information.";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            try
            {
                if (_userService.AuthenticateUser(username, password))
                {

                    return RedirectToAction("Welcome", "Home");
                }
            
            else
            {
                ViewBag.ErrorMessage = "Login failed. Please check your credentials.";
                return View();
            }
        }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception during login");

                
                ViewBag.ErrorMessage = "An error occurred during login. Please try again later.";
                return View();
            }
            //return View("Welcome");
        }

        public ActionResult RegistrationSuccess()
        {
            return RedirectToAction("Login", "Home");
        }
        
    }
}
