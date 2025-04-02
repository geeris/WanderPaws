using System.Text.Json.Serialization;

namespace WanderPaws.Application.DTOs.JWT
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; } = string.Empty;
    }
}
