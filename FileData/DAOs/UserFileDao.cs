using Application.DaoInterfaces;
using Domain.Models;

namespace FileData.DAOs;

//to be able to store the new User.

public class UserFileDao : IUserDao
{

    private readonly FileContext context;

    public
        UserFileDao(
            FileContext context) //We receive an instance of FileContext through constructor dependency injection.
    {
        this.context = context;
    }

    // assign a unique ID, add it to the collection in the FileContext, and save the changes, so that the data is persisted to the file.
    public Task<User> CreateAsync(User user)
    {
        int userId = 1; // are no Users in the storage, then we just set the Id of the new User to be 1.
        if (context.Users.Any())
        {
            userId = context.Users.Max(u =>
                u.Id); //The Max() method looks through all the User objects and returns the max value found from the property Id. The result is incremented, and so we know this int is not currently in use as an ID.
            userId++;
        }

        user.Id = userId;

        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {                                                          //The FirstOrDefault() method will find the first object matching the criteria specified in the lambda expression.If nothing is found, null is returned.
        User? existing = context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) //In the Equals method I specify that the matching should not consider upper/lower case.
        );
        return Task.FromResult(existing);
    }
    
    //add post
    //Given an Id we want to return the associated User, or null if none is found
    public Task<User?> GetByIdAsync(int id)
    {
        User? existing = context.Users.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(existing);
    }
}