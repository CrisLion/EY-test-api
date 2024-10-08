﻿using AutoMapper;
using Suppliers.API.DueDiligence.Domain.Repositories;
using Suppliers.API.Security.Application.Exceptions;
using Suppliers.API.Security.Domain.Models.Aggregates;
using Suppliers.API.Security.Domain.Models.Commands;
using Suppliers.API.Security.Domain.Models.Responses;
using Suppliers.API.Security.Domain.Repositories;
using Suppliers.API.Security.Domain.Services;
using Suppliers.API.Shared.Application.Exceptions;
using Suppliers.API.Shared.Domain.Repositories;

namespace Suppliers.API.Security.Application.Features;

public class UserCommandService : IUserCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IEncryptService _encryptService;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserCommandService(IUserRepository userRepository, IEncryptService encryptService, ITokenService tokenService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _encryptService = encryptService;
        _tokenService = tokenService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<string> Handle(LoginUserCommand command)
    {
        var userInDatabase = await _userRepository.GetUserByUsernameAsync(command.Username);

        if (userInDatabase == null)
        {
            throw new NotFoundEntityAttributeException(nameof(User),nameof(command.Username), command.Username);
        }
        
        if (!_encryptService.Verify(command.Password, userInDatabase.Password))
        {
            throw new IncorrectPasswordException();
        }
        
        return _tokenService.GenerateToken(userInDatabase);
    }

    public async Task<UserResponse> Handle(RegisterUserCommand command)
    {
        var userInDatabase = await _userRepository.GetUserByUsernameAsync(command.Username);

        if (userInDatabase != null)
        {
            throw new DuplicatedUserUsernameException(command.Username);
        }
        
        var userEntity = _mapper.Map<User>(command);
        userEntity.Password = _encryptService.Encrypt(command.Password);

        await _userRepository.SaveAsync(userEntity);
        await _unitOfWork.CompleteAsync();
        
        var userResponse = _mapper.Map<UserResponse>(userEntity);
        return userResponse;

    }

    public Task<UserResponse> Handle(int id, UpdateUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Handle(DeleteUserCommand command)
    {
        throw new NotImplementedException();
    }
}