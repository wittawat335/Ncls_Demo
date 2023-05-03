using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCLS.WEB.Entities;
using NCLS.WEB.Repositories.Contract;

namespace NCLS.WEB.Repositories
{
    public class BucketRepository : IBucketRepository
    {
        private readonly NCLSEntities _dbContext = new NCLSEntities();

        public List<M_BUCKET> Search(string code, string bucketName, decimal? ovdStart, decimal? ovdEnd,
            string status)
        {
            try
            {
                var model = _dbContext.M_BUCKET.Where(x => x.BUCKET_CODE.Contains(code) && x.BUCKET_NAME.Contains(bucketName) && x.BUCKET_STATUS.Contains(status)).ToList();
                if (ovdStart != null || ovdEnd != null)
                    model = model.Where(x => x.BUCKET_OVDDAYS_START >= ovdStart || x.BUCKET_OVDDAYS_END >= ovdEnd).ToList();
                
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public M_BUCKET Detail(string code)
        {
            try
            {
                return _dbContext.M_BUCKET.FirstOrDefault(x => x.BUCKET_CODE == code);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Add(M_BUCKET model)
        {
            try
            {
                _dbContext.M_BUCKET.Add(model);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(M_BUCKET model, string user, DateTime systemDate)
        {
            try
            {
                var m = _dbContext.M_BUCKET.Find(model.BUCKET_CODE);
                m.BUCKET_NAME = model.BUCKET_NAME;
                m.BUCKET_OVDDAYS_START = model.BUCKET_OVDDAYS_START;
                m.BUCKET_OVDDAYS_END = model.BUCKET_OVDDAYS_END;
                m.BUCKET_UPDATE_BY = user;
                m.BUCKET_UPDATE_DATE = systemDate;
                m.BUCKET_STATUS = model.BUCKET_STATUS;
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
                _dbContext.M_BUCKET.Find(code);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}