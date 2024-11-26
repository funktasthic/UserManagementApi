﻿using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.DTOs.User;

public class UserUpdateRequestDto
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}