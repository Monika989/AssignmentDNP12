using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);  //The method takes a post and returns a post (because the Id is set).
  
    //view posts - search
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    
    //view single post  
    Task <Post?> GetByIdAsync(int postId);  
    
}