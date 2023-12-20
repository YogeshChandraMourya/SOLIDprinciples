namespace SOLIDDb_15_12_23_.Models
{
    public class UserService : IUserService
    {
        private readonly SolidContext _context;
        private readonly IEmailService _emailService;


        public UserService(SolidContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public bool RegisterUser(User user)
        {
            try
            {
                // Check if the user with the same username already exists
                if (_context.Users.Any(u => u.Username == user.Username))
                {
                    // User with the same username already exists
                    return false;
                }

                // Add the new user to the database
                _context.Users.Add(user);
                _context.SaveChanges();

                //var emailMessage = new EmailMessage
                //{
                    
                //    Subject = "Registration Successful",
                //    Body = "Thank you for registering!"
                //    // You can add more content to the email body as needed
                //};

                //_emailService.SendEmail(emailMessage);

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For demonstration purposes, we'll return false on error
                return false;
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            try
            {
                // Check if the user with the given username and password exists
                bool userExists = _context.Users.Any(u => u.Username == username && u.Password == password);

                return userExists;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For demonstration purposes, we'll return false on error
                return false;
            }
        }

    }

}
