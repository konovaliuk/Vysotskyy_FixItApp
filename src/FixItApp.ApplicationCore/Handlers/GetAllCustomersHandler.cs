using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<UserEntity>>
{
    private readonly IUserRepository _userRepository;
    
    public GetAllCustomersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<List<UserEntity>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        List <UserEntity> result = await _userRepository.GetAllCustomersAsync(cancellationToken);
        if (result.FirstOrDefault() != null)
            return result;
        throw new Exception();
    }
}