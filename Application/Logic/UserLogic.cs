using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;
    public UserLogic(IUserDao userDao)  
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("This username is already in use! Please choose a different username.");

        ValidateData(dto);
        User toCreate = new User
        {
            UserName = dto.UserName,
            Password = dto.Password
        };
        
        User created = await userDao.CreateAsync(toCreate);
        
        return created;
    }
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        return userDao.GetAsync(searchParameters);
    }

    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;
        string password = userToCreate.Password;
        if (userName.Length < 2)
            throw new Exception("Username must be at least 2 characters!");

        if (userName.Length > 20)
            throw new Exception("Username must be less than 20 characters!");
        
        if(password.Length < 8)
            throw new Exception("Password must be at least 8 characters!");
        
    } 

    
    
    //log in
    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await userDao.GetByUsernameAsync(username);
        
        if (existingUser == null)
        {
            throw new Exception("Username not found or incorrect");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Incorrect password. Please double-check your password and try again.");
        }

        return existingUser;  
    }
}