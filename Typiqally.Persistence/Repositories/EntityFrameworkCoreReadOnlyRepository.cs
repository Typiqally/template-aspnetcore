﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Typiqally.Persistence.Abstractions.Entities;
using Typiqally.Persistence.Abstractions.Repositories;

namespace Typiqally.Persistence.Repositories
{
	public class EntityFrameworkCoreReadOnlyRepository<TEntity, TContext> : IReadOnlyRepository<TEntity>
		where TEntity : class, IEntity
		where TContext : DbContext
	{
		protected readonly TContext Context;

		public EntityFrameworkCoreReadOnlyRepository(TContext context)
		{
			Context = context;
		}

		public IEnumerable<TEntity> AllToList(
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null,
			int? skip = null,
			int? take = null)
		{
			return GetQueryable(null, orderBy, includeProperties, skip, take).ToList();
		}

		public async Task<IEnumerable<TEntity>> AllToListAsync(
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null,
			int? skip = null,
			int? take = null)
		{
			return await GetQueryable(null, orderBy, includeProperties, skip, take).ToListAsync();
		}

		public IEnumerable<TEntity> ToList(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null,
			int? skip = null,
			int? take = null)
		{
			return GetQueryable(filter, orderBy, includeProperties, skip, take).ToList();
		}

		public async Task<IEnumerable<TEntity>> ToListAsync(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null,
			int? skip = null,
			int? take = null)
		{
			return await GetQueryable(filter, orderBy, includeProperties, skip, take).ToListAsync();
		}

		public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter = null, string[] includeProperties = null)
		{
			return GetQueryable(filter, null, includeProperties).SingleOrDefault();
		}

		public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, string[] includeProperties = null)
		{
			return await GetQueryable(filter, null, includeProperties).SingleOrDefaultAsync();
		}

		public TEntity FirstOrDefault(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null)
		{
			return GetQueryable(filter, orderBy, includeProperties).FirstOrDefault();
		}

		public async Task<TEntity> FirstOrDefaultAsync(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null)
		{
			return await GetQueryable(filter, orderBy, includeProperties).FirstOrDefaultAsync();
		}

		public TEntity Find(object id)
		{
			return Context.Set<TEntity>().Find(id);
		}

		public async Task<TEntity> FindAsync(object id)
		{
			return await Context.Set<TEntity>().FindAsync(id);
		}

		public int Count(Expression<Func<TEntity, bool>> filter = null)
		{
			return GetQueryable(filter).Count();
		}

		public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
		{
			return GetQueryable(filter).CountAsync();
		}

		public bool Any(Expression<Func<TEntity, bool>> filter = null)
		{
			return GetQueryable(filter).Any();
		}

		public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
		{
			return GetQueryable(filter).AnyAsync();
		}

		protected virtual IQueryable<TEntity> GetQueryable(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null,
			int? skip = null,
			int? take = null)
		{
			includeProperties ??= Array.Empty<string>();
			IQueryable<TEntity> query = Context.Set<TEntity>();

			if (filter != null) query = query.Where(filter);

			query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			if (orderBy != null) query = orderBy(query);

			if (skip.HasValue) query = query.Skip(skip.Value);

			if (take.HasValue) query = query.Take(take.Value);

			return query;
		}
	}
}