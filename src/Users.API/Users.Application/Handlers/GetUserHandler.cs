using Users.Application.Queries;
using Users.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users;
using Users.Domain.Interface;
namespace Users.Application.Handlers
{
    public class GetUserHandler(IQueriesUser qs) : IRequestHandler<GetUsersQuery, List<UserDTO>>
    {
        public async Task<List<UserDTO>> Handle(GetUsersQuery uq, CancellationToken cancellationToken)
        {
            var user = await qs.GetUsers();
            return user.Select(u => new UserDTO
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            }).ToList();
        }
    }
}