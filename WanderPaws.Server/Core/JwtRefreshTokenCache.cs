using WanderPaws.Application.Interfaces;

public class JwtRefreshTokenCache : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IJwtAuthManager _jwtAuthManager;
    private Timer? _timer;

    public JwtRefreshTokenCache(IServiceProvider serviceProvider, IJwtAuthManager jwtAuthManager)
    {
        _serviceProvider = serviceProvider;
        _jwtAuthManager = jwtAuthManager;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        using var scope = _serviceProvider.CreateScope();
        var httpContextAccessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();

        // Proverite da li postoji HttpContext i uzmite korisničke podatke
        var userId = httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value;

        // Logika za uklanjanje refresh tokena
        _jwtAuthManager.RemoveExpiredRefreshTokens(DateTime.Now);
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
