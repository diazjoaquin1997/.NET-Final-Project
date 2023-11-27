using MediatR;

namespace Application.Contracts
{
    public class GetUserListRequest : IRequest<GetUserListResponse>
    {
        public int? RolId { get; set; }
    }
}
