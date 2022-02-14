using Ardalis.Specification.EntityFrameworkCore;
using CleanArchitecture.SharedKernel.Interfaces;

namespace CleanArchitecture.Infrastructure.Persistence;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(CleanArchitectureContext dbContext) : base(dbContext)
  {
  }
}
