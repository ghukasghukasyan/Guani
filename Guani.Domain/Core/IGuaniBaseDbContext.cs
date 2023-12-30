
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Guani.Domain.Entities;

namespace Guani.Domain.Core
{
    public interface IGuaniBaseDbContext
    {
        IModel Model { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        IQueryable Set(Type entityType);
        string GetTableName(Type type);
        IQueryable<TEntity> FromSqlRaw<TEntity>(string sql, params object[] parameters) where TEntity : class;
        Task<List<TResult>> RunSqlQueryAsync<TResult>(string query, Func<DbDataReader, TResult> map, CancellationToken cancellationToken);
        List<T> RunSqlQuery<T>(string query, Func<DbDataReader, T> map);
        void SetEntityStates<TEntity>(List<TEntity> addedItems, List<TEntity> updatedItems, List<TEntity> deletedItems) where TEntity : EntityBase;
    }
}
