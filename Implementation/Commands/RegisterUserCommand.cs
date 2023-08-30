using Application.Commands.User;
using Application.DataTransfer;
using Application.Email;
using AutoMapper;
using Domain;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class RegisterUserCommand : IRegisterUserCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;

        public RegisterUserCommand(Context context, IMapper mapper, RegisterUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 1;

        public string Name => "User registration.";

        public void Execute(UserCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = _mapper.Map<User>(request);

            int[] useCaseSet = { 1, 2, 3, 4, 5, 6, 7, 8 };

            var userUseCases = new List<UserUseCase>();

            foreach(var i in useCaseSet)
            {
                userUseCases.Add(new UserUseCase
                {
                    UseCaseId = i,
                    User = user
                });
            }

            _context.UserUseCases.AddRange(userUseCases);

            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Content = "<h1>Successfull registration!</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            });
        }
    }
}
