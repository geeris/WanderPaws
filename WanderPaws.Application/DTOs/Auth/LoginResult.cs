using System.Text.Json.Serialization;

namespace WanderPaws.Application.DTOs.Auth
{
    public class LoginResult
    {
        [JsonPropertyName("email")] public string Email { get; set; } = string.Empty;

        [JsonPropertyName("originalEmail")] public string OriginalEmail { get; set; } = string.Empty;

        [JsonPropertyName("accessToken")] public string AccessToken { get; set; } = string.Empty;

        [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; } = string.Empty;
    }
}
