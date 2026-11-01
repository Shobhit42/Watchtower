namespace Watchtower.Domain.Entities;

public class MonitoredSite
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Url { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }

    private MonitoredSite() { }

    public static MonitoredSite Create(Guid userId, string name, string url)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId is required.", nameof(userId));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            throw new ArgumentException("URL must be a valid http or https address.", nameof(url));

        return new MonitoredSite
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Name = name.Trim(),
            Url = uri.ToString(),
            IsActive = true,
            CreatedAtUtc = DateTime.UtcNow
        };
    }

    public void Pause() => IsActive = false;
    public void Resume() => IsActive = true;
}