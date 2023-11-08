using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    
    //view posts filtering
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
  
  // view one post
     Task<PostBasicDto> GetByIdAsync(int id);
}