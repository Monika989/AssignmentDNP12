using Domain.Models;
//a class to hold the data
//read data from the file and load into these two collections-> like database tables
namespace FileData;

public class DataContainer
{
    public ICollection<User> Users { get; set; }
    public ICollection<Post> Posts { get; set; }
}