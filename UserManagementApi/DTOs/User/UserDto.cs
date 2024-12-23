﻿namespace UserManagementApi.DTOs.User;

public class UserDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsActive { get; set; }
}