using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UniStay.Shared.Dtos;

namespace UniStay.Application.Modules.Catalog.User.Queries.GetById
{
    public class GetUserByIdQuery : IRequest<UserDTO?>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }

}
