using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate); 
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);

    //log in 
     Task<User> ValidateUser(string name, string password); 
}