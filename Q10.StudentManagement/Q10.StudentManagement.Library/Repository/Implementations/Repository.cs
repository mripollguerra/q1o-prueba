using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Q10.StudentManagement.Library.Options;
using Q10.StudentManagement.Library.Repository.Abstracts;

namespace Q10.StudentManagement.Library.Repository.Implementations;

public sealed class Repository : IRepository
{
    public Repository(BaseContext context, IOptions<RepositoryOptions> options)
    {
        Context = context;
        if (options.Value.CreateDatabase)
            Context.Database.EnsureCreated();
    }

    public BaseContext Context { get; }

    public DbSet<T> Set<T>() where T : class
    {
        return Context.Set<T>();
    }
}