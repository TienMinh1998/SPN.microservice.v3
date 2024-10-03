﻿using DatabaseCore.Infrastructure.ConfigurationEFContext;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DatabaseCore.Infrastructure.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
    IOrderedQueryable<T>> orderBy = null,
    Func<IQueryable<T>, IIncludableQueryable<T, Object>> include = null);
    Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>,
    IOrderedQueryable<T>> orderBy = null,
    Func<IQueryable<T>, IIncludableQueryable<T, Object>> include = null);
    Task<T> AddAsync(T entity);
    Task<bool> AddManyAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<T> UpdateAsyncAgain(T entity);
    Task DeleteAsync(T entity);
    Task<EnglishDbContext> GetDbContext();
    /// <summary>
    /// Count All entity in the table. can add Condition lamda
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    int Count(Expression<Func<T, bool>> where);
    Task<int> CountAsync(Expression<Func<T, bool>> where = null);
    IEnumerable<T> FromSqlQuery(string sql, bool allowTracking);
    PaginationSet<T> ListPaging(int pageNumber, int pageSize, Func<T, bool> predicate, Dictionary<string, bool> sortList);
    PaginationSet<T> GetListPaged(int pageNumber, int pageSize, Func<T, bool> predicate, string sortColumnName, bool descending = false);
}
