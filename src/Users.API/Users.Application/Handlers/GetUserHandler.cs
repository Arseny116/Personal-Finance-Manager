using Users.Application.Queries;
using Users.Domain.DTOs;
using Users.Domain.Interface;
using MediatR;
using System.Linq;

namespace Users.Application.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUsersQuery, List<UserDTO>>
    {
        private readonly IRepositoryUsers _repositoryUsers;

        public GetUserHandler(IRepositoryUsers repositoryUsers)
        {
            _repositoryUsers = repositoryUsers;
        }

        public async Task<List<UserDTO>> Handle(GetUsersQuery uq, CancellationToken cancellationToken)
        {
          
            var users = _repositoryUsers.GetAllUsers().Result;

           
            var userDtos = users
                .Select(x => new UserDTO(x.FirstName, x.LastName, x.Email))
                .ToList(); 

            return userDtos;
        }
    }
}