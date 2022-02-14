using Ardalis.Specification;

namespace CleanArchitecture.SharedKernel.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
