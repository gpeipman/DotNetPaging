using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using NHibernate;
using NHibernate.Linq;

namespace DotNetPaging.NHibernate
{
    public static class NHibernatePagedResultExtensions
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize)
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        public static async Task<PagedResult<T>> GetPagedAsync<T>(this IQueryable<T> query, int page, int pageSize)
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }

        public static PagedResult<U> GetPaged<T, U>(this IQueryable<T> query, int page, int pageSize) where U : class
        {
            var result = new PagedResult<U>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip)
                                  .Take(pageSize)
                                  .ProjectTo<U>()
                                  .ToList();
            return result;
        }

        public static async Task<PagedResult<U>> GetPagedAsync<T, U>(this IQueryable<T> query, int page, int pageSize) where U : class
        {
            var result = new PagedResult<U>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = await query.CountAsync();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await query.Skip(skip)
                                        .Take(pageSize)
                                        .ProjectTo<U>()
                                        .ToListAsync();
            return result;
        }

        public static PagedResult<T> GetPaged<T>(this ICriteria criteria, int page, int pageSize)
        {
            var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

            criteria.SetMaxResults(pageSize).SetFirstResult((page - 1) * pageSize);

            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;

            result.RowCount = countCriteria.List<int>().First();
            var pageCount = (double)result.RowCount / result.PageSize;

            result.PageCount = (int)Math.Ceiling(pageCount);

            result.Results = criteria.List<T>();

            return result;
        }

        public static async Task<PagedResult<T>> GetPagedAsync<T>(this ICriteria criteria, int page, int pageSize)
        {
            var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

            criteria.SetMaxResults(pageSize).SetFirstResult((page - 1) * pageSize);

            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;

            result.RowCount = (await countCriteria.ListAsync<int>()).First();
            var pageCount = (double)result.RowCount / result.PageSize;

            result.PageCount = (int)Math.Ceiling(pageCount);

            result.Results = await criteria.ListAsync<T>();

            return result;
        }

        public static PagedResult<U> GetPaged<T, U>(this ICriteria criteria, int page, int pageSize)
        {
            var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

            criteria.SetMaxResults(pageSize).SetFirstResult((page - 1) * pageSize);

            var result = new PagedResult<U>();
            result.CurrentPage = page;
            result.PageSize = pageSize;

            result.RowCount = countCriteria.List<int>().First();
            var pageCount = (double)result.RowCount / result.PageSize;

            result.PageCount = (int)Math.Ceiling(pageCount);

            result.Results = criteria.List<T>()
                                     .AsQueryable()
                                     .ProjectTo<U>()
                                     .ToList();
            return result;
        }

        public static async Task<PagedResult<U>> GetPagedAsync<T, U>(this ICriteria criteria, int page, int pageSize)
        {
            var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

            criteria.SetMaxResults(pageSize).SetFirstResult((page - 1) * pageSize);

            var result = new PagedResult<U>();
            result.CurrentPage = page;
            result.PageSize = pageSize;

            result.RowCount = (await countCriteria.ListAsync<int>()).First();
            var pageCount = (double)result.RowCount / result.PageSize;

            result.PageCount = (int)Math.Ceiling(pageCount);

            result.Results = (await criteria.ListAsync<T>())
                                            .AsQueryable()
                                            .ProjectTo<U>()
                                            .ToList();
            return result;
        }

        public static PagedResult<T> GetPaged<T>(this IQueryOver criteria, int page, int pageSize)
        {
            return criteria.RootCriteria.GetPaged<T>(page, pageSize);
        }

        public static async Task<PagedResult<T>> GetPagedAsync<T>(this IQueryOver criteria, int page, int pageSize)
        {
            return await criteria.RootCriteria.GetPagedAsync<T>(page, pageSize);
        }

        public static PagedResult<U> GetPaged<T, U>(this IQueryOver criteria, int page, int pageSize)
        {
            return criteria.RootCriteria.GetPaged<T, U>(page, pageSize);
        }

        public static async Task<PagedResult<U>> GetPagedAsync<T, U>(this IQueryOver criteria, int page, int pageSize)
        {
            return await criteria.RootCriteria.GetPagedAsync<T, U>(page, pageSize);
        }
    }
}