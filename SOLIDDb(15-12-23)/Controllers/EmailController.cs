using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOLIDDb_15_12_23_.Models;

namespace SOLIDDb_15_12_23_.Controllers
{
    public class EmailController : Controller
    {
        private readonly SolidContext _solidContext;

        public EmailController(SolidContext solidContext)

        {
            _solidContext = solidContext;
        }
        public ActionResult Index()
        {
            var emailMessages = _solidContext.EmailMessages.ToList();
            return View(emailMessages);
        }

        public ActionResult EmailSent()
        {
            return View();
        }
    }
}
