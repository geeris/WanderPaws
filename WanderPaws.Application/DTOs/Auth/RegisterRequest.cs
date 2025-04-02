using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WanderPaws.Application.DTOs.Auth
{
    public class RegisterRequest
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}
