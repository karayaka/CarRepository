using System;
using System.Linq.Expressions;
using CarRepository.BLL.Interfaces;
using CarRepository.DAL.CarRepositoryContext;
using CarRepository.Domain.Enums;
using CarRepository.Domain.Models.EntityModels.BaseEntitiys;
using Microsoft.EntityFrameworkCore;

namespace CarRepository.BLL.Repositorys
{
    public class Repository:IRepository
    {
        private readonly CarRepositoryDataContext context;

        public Repository(CarRepositoryDataContext _context)
        {
            context = _context;
        }

        public async Task<T> Add<T>(T model) where T : BaseEntitiy
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                model.Status = Status.NonDeleted;
                await context.AddAsync(model);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> AddRange<T>(IEnumerable<T> models) where T : BaseEntitiy
        {
            try
            {
                foreach (var item in models)
                {
                    await Add(item);
                }
                return models;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AnyNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy
        {
            try
            {
                return GetNonDeleted<T>(expression).Any();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CountNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy
        {
            try
            {
                return GetNonDeleted<T>(expression).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete<T>(int ID) where T : BaseEntitiy
        {
            try
            {
                var model = await GetByID<T>(ID);
                Delete(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete<T>(T model) where T : BaseEntitiy
        {
            try
            {
                model.Status = Status.Deleted;
                Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Find<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> FindNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy
        {
            return await context.Set<T>().Where(t=>t.Status==Status.NonDeleted).FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy
        {
            try
            {
                return context.Set<T>().Where(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetByID<T>(int ID) where T : BaseEntitiy
        {
            try
            {
                return await Find<T>(t => t.ID == ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntitiy
        {
            try
            {
                return Get<T>(t => t.Status == Status.NonDeleted).Where(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveChange()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update<T>(T model) where T : BaseEntitiy
        {
            try
            {
                context.Update(model);    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

