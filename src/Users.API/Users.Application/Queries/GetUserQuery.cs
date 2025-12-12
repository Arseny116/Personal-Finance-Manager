using MediatR;
using Users.Domain.DTOs;


namespace Users.Application.Queries
{
    /// <summary>
    /// IRequest<UserDTO[]> - UserDTO тип возвращаемого обьекта
    /// </summary>
    public class GetUsersQuery() : IRequest<List<UserDTO>>
    {
    }
}
