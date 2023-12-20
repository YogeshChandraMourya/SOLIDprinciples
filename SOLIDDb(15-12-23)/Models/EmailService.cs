using System.Net.Mail;
using System.Net;

namespace SOLIDDb_15_12_23_.Models
{
    public class EmailService:IEmailService
    {
        private readonly SolidContext _context;


        public EmailService(SolidContext context)
        {
            _context = context;
        }

        public void SendEmail(EmailMessage message)
        {
            try
            {
                // Save the email message to the database
                _context.EmailMessages.Add(message);
                _context.SaveChanges();

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
        }
    }
}
