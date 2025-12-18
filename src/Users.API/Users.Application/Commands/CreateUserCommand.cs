using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Users.Application.Commands
{
    public record CreateUserCommand(string FirstName, string LastName , string Password)  : IRequest;
}
