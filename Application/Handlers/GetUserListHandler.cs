using Application.Contracts;
using Application.Models;
using Application.Profiles;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.Handlers
{
    public class GetUserListHandler : IRequestHandler<GetUserListRequest, GetUserListResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetUserListRequest> _validator;

        public GetUserListHandler(IUserRepository userRepository, IMapper mapper, IValidator<GetUserListRequest> validator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GetUserListResponse> Handle(
            GetUserListRequest request, CancellationToken cancellationToken)
        {
            var response = new GetUserListResponse();

            var result = _validator.Validate(request);
            if (!result.IsValid)
                throw new Exception(result.Errors.ToString());

            var users = _userRepository.GetList();

            if (request.RolId.HasValue)
            {
                response.UserList = users
                    .Where(u => u.RolId == request.RolId)
                    .Select(x => MapTo(x))
                    .ToList();
            }
            else
            {
                response.UserList = users
                    .Select(x => MapTo(x))
                    .ToList();
            }          

            return response;
        }

        private UserDto MapTo(User user)
        {
            return _mapper.Map<UserDto>(user);
        }
    }
}
