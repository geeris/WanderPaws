using System.Text.Json.Serialization;

namespace BudgetBloom.Application.DTOs.JWT
{
    public class RefreshToken
    {
        [JsonPropertyName("email")] public string Email { get; set; } = string.Empty;    // can be used for usage tracking
                                                                                         // can optionally include other metadata, such as user agent, ip address, device name, and so on
        [JsonPropertyName("tokenString")] public string TokenString { get; set; } = string.Empty;

        [JsonPropertyName("expireAt")] public DateTime ExpireAt { get; set; }
    }
}
