namespace Watchtower.Domain.Entities;

public class Incident
{
    public Guid Id { get; private set; }
    public Guid MonitoredSiteId { get; private set; }
    public DateTime StartedAtUtc { get; private set; }
    public DateTime? ResolvedAtUtc { get; private set; }
    public string? FirstErrorMessage { get; private set; }
    public uint RowVersion { get; private set; }
    public bool IsOpen => ResolvedAtUtc is null;
    public TimeSpan? Duration => ResolvedAtUtc - StartedAtUtc;

    private Incident() { }

    public static Incident Open(Guid siteId, DateTime startedAtUtc, string? firstErrorMessage)
    {
        if (siteId == Guid.Empty)
            throw new ArgumentException("MonitoredSiteId is required.", nameof(siteId));

        return new Incident
        {
            Id = Guid.NewGuid(),
            MonitoredSiteId = siteId,
            StartedAtUtc = startedAtUtc,
            FirstErrorMessage = firstErrorMessage
        };
    }

    public bool Resolve(DateTime resolvedAtUtc)
    {
        if (!IsOpen)
            return false;

        if (resolvedAtUtc < StartedAtUtc)
            throw new ArgumentException("Cannot resolve before the incident started.", nameof(resolvedAtUtc));

        ResolvedAtUtc = resolvedAtUtc;
        return true;
    }
}