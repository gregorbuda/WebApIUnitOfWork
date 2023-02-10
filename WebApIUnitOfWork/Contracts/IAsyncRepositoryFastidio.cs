﻿using System.Linq.Expressions;

namespace WebApIUnitOfWork.Contracts
{
    public interface IAsyncRepositoryFastidio<T> where T : class, new()
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsyncById(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       string includeString = null,
                                       bool disableTracking = true);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       List<Expression<Func<T, object>>> includes = null,
                                       bool disableTracking = true);

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        void AddEntity(T entity);
        void UpdateEntity(T entity);

        void DeleteEntity(T entity);

        void DeleteBatch(IEnumerable<T> itemList);

        void UpdateBatch(IEnumerable<T> itemList);

        void SaveBatch(IEnumerable<T> itemList);
    }
}
