using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UniStay.Shared.Dtos;

namespace UniStay.Application.Modules.Catalog.User.Queries.List
{
    public record GetAllUsersQuery() : IRequest<List<UserDTO>>;
}
