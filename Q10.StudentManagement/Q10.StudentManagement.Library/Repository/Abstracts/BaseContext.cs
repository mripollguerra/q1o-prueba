using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Q10.StudentManagement.Library.Options;

namespace Q10.StudentManagement.Library.Repository.Abstracts;

public abstract class BaseContext : DbContext
{
    private readonly RepositoryOptions _repositoryOptions;

    protected BaseContext(
        DbContextOptions dbContextOptions,
        IServiceProvider serviceProvider,
        IOptions<RepositoryOptions> repositoryOptions
    ) : base(dbContextOptions)
    {
        _repositoryOptions = repositoryOptions.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        switch (_repositoryOptions.Provider)
        {
            case "MySql":
                var serverVersion = GetDbVersion(_repositoryOptions.ConnectionString);
                optionsBuilder.UseMySql(_repositoryOptions.ConnectionString, serverVersion,
                    o => o.EnableRetryOnFailure(_repositoryOptions.RetryCount,
                        TimeSpan.FromMilliseconds(_repositoryOptions.MaxRetryDelay), null));
                break;
            case "SqlServer":
                optionsBuilder.UseSqlServer(_repositoryOptions.ConnectionString,
                    o => o.EnableRetryOnFailure(_repositoryOptions.RetryCount,
                        TimeSpan.FromMilliseconds(_repositoryOptions.MaxRetryDelay), null));
                break;
            default:
                throw new NotSupportedException("Provider not supported");
        }

        base.OnConfiguring(optionsBuilder);
    }

    private MySqlServerVersion GetDbVersion(string connectionString)
    {
        try
        {
            return new MySqlServerVersion(_repositoryOptions.DbVersion);
        }
        catch
        {
            return new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
        }
    }
}