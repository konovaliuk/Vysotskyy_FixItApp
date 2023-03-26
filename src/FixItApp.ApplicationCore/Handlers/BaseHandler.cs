using FixItApp.ApplicationCore.Interfaces;

namespace FixItApp.ApplicationCore.Handlers;

public class BaseHandler
{
    protected readonly IUserRepository _userRepository;
    protected readonly IMapper _mapper;

    protected BaseHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
}