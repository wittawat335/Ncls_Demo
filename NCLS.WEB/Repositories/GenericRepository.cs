using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCLS.WEB.Entities;
using NCLS.WEB.Repositories.Contract;

namespace NCLS.WEB.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly NCLSEntities _dbContext = new NCLSEntities();
        public void Add(T model)
        {
            try
            {
                _dbContext.Set<T>().Add(model);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

      

        public void CheckDuplicate(string code)
        {
            try
            {
                _dbContext.Set<T>().Find(code);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}