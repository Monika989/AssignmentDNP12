using Domain.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user); 
    Task<User?> GetByUsernameAsync(string userName);
    
    //add post
    Task<User?> GetByIdAsync(int id);
}