using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCLS.WEB.Entities;

namespace NCLS.WEB.Repositories.Contract
{
    public interface IBucketRepository
    {
        List<M_BUCKET> Search(string code, string bucketName, decimal? ovdStart, decimal? ovdEnd, string status);
        M_BUCKET Detail(string code);
        void Add(M_BUCKET model);
        void Update(M_BUCKET model, string user, DateTime systemDate);
        void CheckDuplicate(string code);
    }
}
