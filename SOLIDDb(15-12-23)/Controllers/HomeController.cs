using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOLIDDb_15_12_23_.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace SOLIDDb_15_12_23_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SolidContext _context;
        

        public HomeController(ILogger<HomeController> logger,SolidContext solidContext)
        {
            _logger = logger;
            _context = solidContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult SendEmail() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(EmailMessage message)
        {
            try
            {
                // Save the email message to the database
                //_context.EmailMessages.Add(message);
                //_context.SaveChanges();

                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587; // Use the appropriate port for your SMTP server
                    smtpClient.Credentials = new NetworkCredential("bychmourya3@gmail.com", "twaqzjgznygnogxl");
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("bychmourya3@gmail.com"),
                        Subject = message.Subject,
                        Body = message.Body,
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(new MailAddress(message.ToAddress));

                    smtpClient.Send(mailMessage);
                }

                Console.WriteLine($"Email sent to {message.ToAddress} with subject: {message.Subject}");

            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        
    
            return View("EmailSent");
        }

        public ActionResult EmailSent()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Welcome()
        {
            return View();
        }
    }
}