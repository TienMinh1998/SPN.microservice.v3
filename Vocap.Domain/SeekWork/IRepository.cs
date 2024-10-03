﻿
namespace Vocap.Domain.SeekWork;
public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
