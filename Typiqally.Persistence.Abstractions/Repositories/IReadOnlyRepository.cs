﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Typiqally.Persistence.Abstractions.Entities;

namespace Typiqally.Persistence.Abstractions.Repositories
{
	public interface IReadOnlyRepository<TEntity>
		where TEntity : class, IEntity
	{
		IEnumerable<TEntity> AllToList(
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null,
			int? skip = null,
			int? take = null);

		Task<IEnumerable<TEntity>> AllToListAsync(
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null,
			int? skip = null,
			int? take = null);

		IEnumerable<TEntity> ToList(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null,
			int? skip = null,
			int? take = null);

		Task<IEnumerable<TEntity>> ToListAsync(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null,
			int? skip = null,
			int? take = null);

		TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter = null, string[] includeProperties = null);

		Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, string[] includeProperties = null);

		TEntity FirstOrDefault(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null);

		Task<TEntity> FirstOrDefaultAsync(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string[] includeProperties = null);

		TEntity Find(object id);

		Task<TEntity> FindAsync(object id);

		int Count(Expression<Func<TEntity, bool>> filter = null);

		Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);

		bool Any(Expression<Func<TEntity, bool>> filter = null);

		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);
	}
}