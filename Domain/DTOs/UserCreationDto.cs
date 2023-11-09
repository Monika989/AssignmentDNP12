namespace Domain.DTOs;
//a new DTO with just the properties needed to create a new User.
public class UserCreationDto
{
    public string UserName { get;}
public string Password { get; }
    public UserCreationDto(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}