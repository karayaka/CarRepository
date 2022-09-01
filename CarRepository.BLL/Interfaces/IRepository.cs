using System;
using System.Linq.Expressions;
using CarRepository.Domain.Models.EntityModels.BaseEntitiys;
using CarRepository.Domain.Models.EntityModels.VehicleModels;

namespace CarRepository.BLL.Interfaces
{
    public interface IRepository
    {
        /// <summary>
        /// Get Queryable All Object
        /// </summary>
        /// <typeparam name="T">DbModel</typeparam>
        /// <param name="expression">Query</param>
        /// <returns></returns>
        IQueryable<T> Get<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy;
        /// <summary>
        /// Get Queryable NonDeleted Object All Object
        /// </summary>
        /// <typeparam name="T">DbModel</typeparam>
        /// <param name="expression">Query</param>
        /// <returns></returns>
        IQueryable<T> GetNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy;
        /// <summary>
        /// Get Onject Bey ID
        /// </summary>
        /// <typeparam name="T">Db Model</typeparam>
        /// <param name="ID">Objetc ID</param>
        /// <returns></returns>
        Task<T> GetByID<T>(int ID) where T : BaseEntitiy;
        /// <summary>
        /// Find Object By Query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<T> Find<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy;
        /// <summary>
        /// Find Nondeleted Object By Query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<T> FindNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy;
        /// <summary>
        /// Update Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        void Update<T>(T model) where T : BaseEntitiy;
        /// <summary>
        /// Delete Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task Delete<T>(int ID) where T : BaseEntitiy;
        /// <summary>
        /// Delete Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete<T>(T model) where T : BaseEntitiy;
        /// <summary>
        /// Add Object to db
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<T> Add<T>(T model) where T : BaseEntitiy;
        /// <summary>
        /// Add List To Db
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="models"></param>
        /// <returns></returns>
        Task<IEnumerable<T>>AddRange<T>(IEnumerable<T> models) where T : BaseEntitiy;

        /// <summary>
        /// Count NonDeleted Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        int CountNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy;
        /// <summary>
        /// Any Non Deleted Onject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool AnyNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy;
        /// <summary>
        /// Save All Changes
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChange();
    }
}

