using Users.Application.Queries;
using Users.Domain.DTOs;
using MediatR;
using Users.Domain.Interface;
namespace Users.Application.Handlers
{
    public class GetUserHandler(IQueriesUser qs) : IRequestHandler<GetUsersQuery, List<UserDTO>>
    {
        public async Task<List<UserDTO>> Handle(GetUsersQuery uq, CancellationToken cancellationToken)
        {
            return await qs.GetAllUsers();
        }
    }
}