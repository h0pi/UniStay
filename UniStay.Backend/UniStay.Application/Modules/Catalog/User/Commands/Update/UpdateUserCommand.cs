using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace UniStay.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }                 // Id korisnika kojeg ažuriraš
        public string Username { get; set; } = "";  // novi username
        public string Email { get; set; } = "";     // novi email
        public string Password { get; set; } = "";  // nova šifra (privremeno plain text)
        public int UserRoleId { get; set; }         // nova rola
    }
}

