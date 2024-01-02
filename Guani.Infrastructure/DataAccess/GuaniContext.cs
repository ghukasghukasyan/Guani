using Guani.Domain.Core;
using Guani.Domain.Entities;
using Guani.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineShop.Domain.Entities.Order;
using System.Data;
using System.Data.Common;

namespace Guani.Infrastructure.DataAccess
{
    public class GuaniContext : DbContext, IGuaniBaseDbContext, IGuaniContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public GuaniContext(DbContextOptions<GuaniContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDbFunction(typeof(CustomEFFunctions).GetMethod("JsonbPathQueryFirst"), delegate (DbFunctionBuilder builder)
            //{
            //    builder.HasParameter("json").HasStoreType("jsonb");
            //    builder.HasTranslation((IReadOnlyList<SqlExpression> args) => new SqlFunctionExpression("jsonb_path_query_first", args, nullable: false, args.Select((SqlExpression x) => false), typeof(string), null));
            //});
            //modelBuilder.HasDbFunction(typeof(CustomEFFunctions).GetMethod("JsonbPathExists"), delegate (DbFunctionBuilder builder)
            //{
            //    builder.HasParameter("json").HasStoreType("jsonb");
            //    builder.HasTranslation((IReadOnlyList<SqlExpression> args) => new SqlFunctionExpression("jsonb_path_exists", args, nullable: false, args.Select((SqlExpression x) => false), typeof(bool), null));
            //});
            //modelBuilder.HasDbFunction(typeof(CustomEFFunctions).GetMethod("ToJsonb"), delegate (DbFunctionBuilder builder)
            //{
            //    builder.HasParameter("json").HasStoreType("jsonb");
            //    builder.HasTranslation((IReadOnlyList<SqlExpression> args) => new SqlFunctionExpression("to_jsonb", args, nullable: false, args.Select((SqlExpression x) => false), typeof(string), null));
            //});
            //modelBuilder.HasDbFunction(typeof(CustomEFFunctions).GetMethod("JsonbArrayElements"), delegate (DbFunctionBuilder builder)
            //{
            //    builder.HasParameter("json").HasStoreType("jsonb");
            //    builder.HasTranslation((IReadOnlyList<SqlExpression> args) => new SqlFunctionExpression("jsonb_array_elements", args, nullable: false, args.Select((SqlExpression x) => false), typeof(string), null));
            //});
            //base.OnModelCreating(modelBuilder);
        }

        public IQueryable Set(Type entityType)
        {
            return (IQueryable)GetType().GetMethod("Set", 1, Array.Empty<Type>()).MakeGenericMethod(entityType).Invoke(this, null);
        }

        public string GetTableName(Type type)
        {
            return Model.FindEntityType(type).GetTableName();
        }

        public IQueryable<TEntity> FromSqlRaw<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            return Set<TEntity>().FromSqlRaw(sql, parameters);
        }

        public async Task<List<TResult>> RunSqlQueryAsync<TResult>(string query, Func<DbDataReader, TResult> map, CancellationToken cancellationToken)
        {
            using DbCommand command = Database.GetDbConnection().CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            await Database.OpenConnectionAsync(cancellationToken);
            using DbDataReader result = await command.ExecuteReaderAsync(cancellationToken);
            List<TResult> entities = new List<TResult>();
            while (await result.ReadAsync(cancellationToken))
            {
                entities.Add(map(result));
            }

            return entities;
        }

        public List<TResult> RunSqlQuery<TResult>(string query, Func<DbDataReader, TResult> map)
        {
            using DbCommand dbCommand = Database.GetDbConnection().CreateCommand();
            dbCommand.CommandText = query;
            dbCommand.CommandType = CommandType.Text;
            Database.OpenConnection();
            using DbDataReader dbDataReader = dbCommand.ExecuteReader();
            List<TResult> list = new List<TResult>();
            while (dbDataReader.Read())
            {
                list.Add(map(dbDataReader));
            }

            return list;
        }

        public void SetEntityStates<TEntity>(List<TEntity> addedItems, List<TEntity> updatedItems, List<TEntity> deletedItems) where TEntity : EntityBase
        {
            if (addedItems != null && addedItems.Any())
            {
                IEnumerable<EntityEntry<TEntity>> source = from x in ChangeTracker.Entries<TEntity>()
                                                           where addedItems.Select((y) => y.Id).Contains(x.Entity.Id)
                                                           select x;
                foreach (TEntity item3 in addedItems)
                {
                    EntityEntry<TEntity> entityEntry = source.First((x) => x.Entity.Id == item3.Id);
                    entityEntry.State = EntityState.Added;
                }
            }

            if (updatedItems != null && updatedItems.Any())
            {
                IEnumerable<EntityEntry<TEntity>> source2 = from x in ChangeTracker.Entries<TEntity>()
                                                            where updatedItems.Select((y) => y.Id).Contains(x.Entity.Id)
                                                            select x;
                foreach (TEntity item2 in updatedItems)
                {
                    EntityEntry<TEntity> entityEntry2 = source2.First((x) => x.Entity.Id == item2.Id);
                    entityEntry2.State = EntityState.Modified;
                }
            }

            if (deletedItems == null || !deletedItems.Any())
            {
                return;
            }

            IEnumerable<EntityEntry<TEntity>> source3 = from x in ChangeTracker.Entries<TEntity>()
                                                        where deletedItems.Select((y) => y.Id).Contains(x.Entity.Id)
                                                        select x;
            foreach (TEntity item in deletedItems)
            {
                EntityEntry<TEntity> entityEntry3 = source3.First((x) => x.Entity.Id == item.Id);
                entityEntry3.State = EntityState.Deleted;
            }
        }
    }


}

