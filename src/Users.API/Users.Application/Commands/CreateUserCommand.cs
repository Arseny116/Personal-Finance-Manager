using MediatR;
using Users.Domain.Entities;

namespace Users.Application.Commands
{
    public record CreateUserCommand(User user)  : IRequest;
}
