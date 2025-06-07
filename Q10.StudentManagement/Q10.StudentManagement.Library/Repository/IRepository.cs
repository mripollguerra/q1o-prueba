using Microsoft.EntityFrameworkCore;
using Q10.StudentManagement.Library.Repository.Abstracts;

namespace Q10.StudentManagement.Library.Repository;

public interface IRepository
{
    public BaseContext Context { get; }
    public DbSet<T> Set<T>() where T : class;
}