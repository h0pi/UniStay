using MediatR;
using Microsoft.EntityFrameworkCore;
using UniStay.Application.Modules.Catalog.User.Queries.GetById;
using UniStay.Shared.Dtos;

namespace UniStay.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO?>
    {
        private readonly IAppDbContext _context;

        public GetUserByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDTO?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(x => x.Role)
                .Where(x => x.Id == request.Id)
                .Select(x => new UserDTO
                {
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email,
                    RoleName = x.Role.RoleName
                })
                .FirstOrDefaultAsync(cancellationToken);

            return user;
        }
    }
}
