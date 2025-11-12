using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using UniStay.Application.Modules.Catalog.User.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IAppDbContext _context;
    //private readonly IPasswordHasher _passwordHasher; // ako imaš
    public CreateUserCommandHandler(IAppDbContext context/*, IPasswordHasher passwordHasher*/)
    {
        _context = context;
        //_passwordHasher = passwordHasher;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var emailExists = await _context.Users
                .AnyAsync(x => x.Email == request.Email, cancellationToken);

        if (emailExists)
            throw new InvalidOperationException($"User with email '{request.Email}' already exists.");


        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            RoleId = request.UserRoleId
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}

