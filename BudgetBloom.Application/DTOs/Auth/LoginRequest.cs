﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BudgetBloom.Application.DTOs.Auth
{
    public class LoginRequest
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}
