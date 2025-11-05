using MediatR;
using Microsoft.EntityFrameworkCore;
using UniStay.Application.Modules.Catalog.User.Queries.List;
using UniStay.Shared.Dtos;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
{
    private readonly IAppDbContext _context;

    public GetAllUsersQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users
            .Include(x => x.Role)
            .Select(x => new UserDTO
            {
                Id = x.Id,
                Username = x.Username,
                Email = x.Email,
                RoleName = x.Role.RoleName
            })
            .ToListAsync(cancellationToken);

        return users;
    }

   
}
