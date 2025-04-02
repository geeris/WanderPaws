using System.Text.Json.Serialization;

namespace WanderPaws.Application.DTOs.JWT
{
    public class ImpersonationRequest
    {
        [JsonPropertyName("email")] public string Email { get; set; } = string.Empty;
    }
}
