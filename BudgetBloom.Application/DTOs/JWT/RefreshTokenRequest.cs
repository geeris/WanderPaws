using System.Text.Json.Serialization;

namespace BudgetBloom.Application.DTOs.JWT
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; } = string.Empty;
    }
}
