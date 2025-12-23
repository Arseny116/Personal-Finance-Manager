using MediatR;
using Users.Application.Commands;
using Users.Domain.Interface;

namespace Users.Application.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUsersRepository _usersRepository;
        public CreateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository; 
        }
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
             await  _usersRepository.CreateUser(request.user);

        }

    }
}
