using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCLS.WEB.Entities;
using NCLS.WEB.Repositories;
using NCLS.WEB.Repositories.Contract;
using NCLS.WEB.Services.Contract;

namespace NCLS.WEB.Services
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository _repository;

        public BucketService()
        {
            this._repository = new BucketRepository();
        }

        public List<M_BUCKET> Search(string code, string bucketName, decimal? ovdStart, decimal? ovdEnd, string status)
        {
            try
            {
                return _repository.Search(code, bucketName, ovdStart, ovdEnd, status);
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
                return _repository.Detail(code);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Add(M_BUCKET model)
        {
            try
            {
                _repository.Add(model);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(M_BUCKET model, string user, DateTime systemDate)
        {
            try
            {
                _repository.Update(model, user, systemDate);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckDuplicate(string code)
        {
            try
            {
                _repository.CheckDuplicate(code);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}