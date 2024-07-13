using BachelorproefVueScanner.Domain.Scans;

namespace BachelorproefVueScanner.Shared.Scans;

public interface IScanService
{
    Task<IEnumerable<Scan>> GetScansAsync();
    Task<Scan> CreateScanAsync(Scan scan);
}
