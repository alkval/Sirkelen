public interface IAuthenticationService
{
    Task<User> LoginAsync(string email, string password);

}