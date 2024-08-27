﻿using Suppliers.API.Security.Domain.Services;

namespace Suppliers.API.Security.Application.Features;

public class EncryptService : IEncryptService
{
    public string Encrypt(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string passwordHashed)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHashed);
    }
}