using MediatR;
using Microsoft.EntityFrameworkCore;
using UniStay.Domain.Entities;

namespace UniStay.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public UpdateUserCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (user == null)
                throw new KeyNotFoundException($"User with ID {request.Id} not found.");

            user.Username = request.Username;
            user.Email = request.Email;
            user.PasswordHash = request.Password; // privremeno bez hashiranja
            user.RoleId = request.UserRoleId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

