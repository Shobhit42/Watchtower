namespace Watchtower.Domain.Entities;

public class CheckResult
{
    public Guid Id { get; private set; }
    public Guid MonitoredSiteId { get; private set; }
    public DateTime CheckedAtUtc { get; private set; }
    public bool IsSuccess { get; private set; }
    public int? StatusCode { get; private set; } 
    public int LatencyMs { get; private set; }
    public string? ErrorMessage { get; private set; }

    private CheckResult() { }

    public static CheckResult Success(Guid siteId, DateTime checkedAtUtc, int statusCode, int latencyMs)
    {
        Validate(siteId, latencyMs);
        return new CheckResult
        {
            Id = Guid.NewGuid(),
            MonitoredSiteId = siteId,
            CheckedAtUtc = checkedAtUtc,
            IsSuccess = true,
            StatusCode = statusCode,
            LatencyMs = latencyMs
        };
    }

    public static CheckResult Failure(Guid siteId, DateTime checkedAtUtc, int latencyMs,
                                      int? statusCode, string errorMessage)
    {
        Validate(siteId, latencyMs);
        return new CheckResult
        {
            Id = Guid.NewGuid(),
            MonitoredSiteId = siteId,
            CheckedAtUtc = checkedAtUtc,
            IsSuccess = false,
            StatusCode = statusCode,
            LatencyMs = latencyMs,
            ErrorMessage = errorMessage
        };
    }

    private static void Validate(Guid siteId, int latencyMs)
    {
        if (siteId == Guid.Empty)
            throw new ArgumentException("MonitoredSiteId is required.", nameof(siteId));
        if (latencyMs < 0)
            throw new ArgumentException("Latency cannot be negative.", nameof(latencyMs));
    }
}