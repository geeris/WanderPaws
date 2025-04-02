using System.Text.Json.Serialization;

namespace WanderPaws.Application.DTOs.JWT
{
    public class JwtAuthResult
    {
        [JsonPropertyName("accessToken")] public string AccessToken { get; set; } = string.Empty;

        [JsonPropertyName("refreshToken")] public RefreshToken RefreshToken { get; set; } = new();
    }
}
