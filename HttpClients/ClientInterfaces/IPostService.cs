using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    //to create posts
    Task<int> CreateAsync( PostCreationDto dto); 
    
    //view all posts

 Task<ICollection<Post>> GetAsync(  
     string? userName, 
     int? userId, 
     string? titleContains,
     string? bodyContains
 );
 
 //get post by id 
 Task<PostBasicDto> GetByIdAsync(int id);
}