using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loyalty.Service
{
    public partial class EfRepository<T> : IRepository<T> where T : class, new()
    {
        #region Fields
        private readonly LoyaltyDbContext _loyaltyDbContext;
        private DbSet<T> _dbSet;


        #endregion

        #region Ctor
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="loyaltyDbContext"></param>
        public EfRepository(LoyaltyDbContext loyaltyDbContext)
        {
            this._loyaltyDbContext = loyaltyDbContext;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get Entity with Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(Guid id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return this.Entities.ToList();
        }
        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null!");
            this.Entities.Add(entity);
            this._loyaltyDbContext.SaveChanges();
        }

        /// <summary>
        /// Insert Entities
        /// </summary>
        /// <param name="entities"></param>
        public void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("Entities are null!");
                foreach (var item in entities)
                    this.Entities.Add(item);
                this._loyaltyDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("Entitiy is null!");
                this._loyaltyDbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update Entities
        /// </summary>
        /// <param name="entities"></param>
        public void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("Entities are null!");
                this._loyaltyDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("Entity is null!");
                this.Entities.Remove(entity);
                this._loyaltyDbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Delete Entities
        /// </summary>
        /// <param name="entities"></param>
        public void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("Entities are null!");
                foreach (var item in entities)
                    this.Entities.Remove(item);
                this._loyaltyDbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Properties
        /// <summary>
        /// Set Entities
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_dbSet == null)
                {
                    _dbSet = _loyaltyDbContext.Set<T>();
                }
                return _dbSet;
            }
        }

        /// <summary>
        /// Gets a Table
        /// </summary>
        public IQueryable<T> Table { get { return this.Entities; } }
        #endregion
    }
}
