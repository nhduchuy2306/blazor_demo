using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Repositories;

namespace ServerLibrary.Services.impl;

public class RoleService : IRoleService
{
    private readonly RoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(RoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public IEnumerable<RoleDTO> GetAll()
    {
        var roles = _roleRepository.GetAll();
        return _mapper.Map<IEnumerable<RoleDTO>>(roles);
    }

    public RoleDTO GetById(int id)
    {
        throw new NotImplementedException();
    }
}
