public class UserService(SirkelenContext context) : IUserService
{
    public async Task<User> GetUserAsync(Guid id)
    {
        return await context.Users.FindAsync(id);
    }

    // TODO Implement the rest of the methods
}