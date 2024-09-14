using ServerLibrary.Models;

namespace ServerLibrary.Repositories;

public class RoleRepository : Repository<Role, int>
{
    public RoleRepository(ManagementdbContext context) : base(context)
    {
    }
}
