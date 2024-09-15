using ServerLibrary.Dtos;

namespace ServerLibrary.Services;

public interface IRoleService
{
    IEnumerable<RoleDTO> GetAll();
    
    RoleDTO GetById(int id);
}
