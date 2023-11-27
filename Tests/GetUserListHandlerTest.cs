using Application.Contracts;
using Application.Handlers;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Tests
{
    public class GetUserListHandlerTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IValidator<GetUserListRequest>> _validator;

        private GetUserListHandler handler;
        public GetUserListHandlerTest()
        {
            var userDto = new UserDto() { Id = 123, Name = "Joa", RolId=1005 };

            var result = new FluentValidation.Results.ValidationResult();

            var usersList = new List<User>()
            {
                new User() {Id = 32,Name="Joa",RolId=1005},
                new User() {Id = 54,Name="Ludmi",RolId=1005},
            };

            _validator = new Mock<IValidator<GetUserListRequest>>();
            _validator
                .Setup(validator => validator.Validate(It.IsAny<GetUserListRequest>()))
                .Returns(result);

            _userRepository = new Mock<IUserRepository>();
            _userRepository.Setup(repo => repo.GetList())
                .Returns(usersList);

            _mapper = new Mock<IMapper>();
            _mapper
                .Setup(m => m.Map<UserDto>(It.IsAny<User>()))
                .Returns(userDto);

            handler = new GetUserListHandler(_userRepository.Object, _mapper.Object, _validator.Object);
        }

        [Fact]
        public async void CuandoObtengoRequestValido_RetornoResponseValido()
        {
            //arrange
            
            //act
            var response = await handler.Handle(new GetUserListRequest(), CancellationToken.None);

            //assert
            Assert.NotNull(response);
            Assert.NotNull(response.UserList);
            response.UserList.ForEach(user => Assert.NotEqual(0, user.RolId));
        }
    }
}