namespace Q10.StudentManagement.Library.Options;

public class RepositoryOptions
{
    public string ConnectionString { get; set; }
    public int RetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public string Provider { get; set; }
    public string DbVersion { get; set; }
    public bool CreateDatabase { get; set; }
}