namespace SOLIDDb_15_12_23_.Models
{
    public interface IUserService
    {
        bool RegisterUser(User user);
        bool AuthenticateUser(string username, string password);
    }
}
