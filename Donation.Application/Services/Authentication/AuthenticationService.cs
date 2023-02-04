﻿using Donation.Application.Common.DuplicateEmailException;
using Donation.Application.Common.Errors;
using Donation.Application.Common.Interfaces.Authentication;
using Donation.Application.Common.Persistence;
using Donation.Domain.Entities;
using FluentResults;

namespace Donation.Application.Servicies.Authentication
{

  public class AuthenticationService : IAuthenticationService
  {
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public AuthenticationService(
      IJwtTokenGenerator jwtTokenGenerator,
      IUserRepository userRepository

      )
    {
      this.jwtTokenGenerator = jwtTokenGenerator;
      this.userRepository = userRepository;
    }
    public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
      // Check if user already exists
      if (userRepository.GetUserByEmail(email) != null)
      {
        // Old Impl without using OneOf
        //throw new DuplicateEmailException("User with given email already exists");
        // Old
        //return new DuplicationEmailError();

        // FluentResult as the ability multiple errors
        //return Result.Fail<AuthenticationResult>(new DuplicationEmailError());
        return Result.Fail<AuthenticationResult>(new[] { new DuplicationEmailError() });

      }

      // Create user (generate unique Id)
      var user = new User
      {
        FirstName = firstName,
        LastName = lastName,
        Email = email,
        Password = password
      };

      userRepository.Add(user);

      // Create JWT token
      var token = jwtTokenGenerator.GenerateToken(user);
      return new AuthenticationResult(
        user,
        token
      );
    }
    public AuthenticationResult Login(string email, string password)
    {
      // 1. Validate the User exists 
      if (userRepository.GetUserByEmail(email) is not User user)
      {
        throw new Exception("User with given email not exists");
      }
      // 2. Validate the Password is Correct
      if (user.Password != password)
      {
        throw new Exception("Invalid Password.");
      }
      // 3. Create JWT token

      var token = jwtTokenGenerator.GenerateToken(user);

      return new AuthenticationResult(
        user,
        token
      );
    }

  }
}
