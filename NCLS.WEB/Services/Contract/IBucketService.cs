using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCLS.WEB.Entities;

namespace NCLS.WEB.Services.Contract
{
    public interface IBucketService
    {
        List<M_BUCKET> Search(string code, string bucketName, decimal? ovdStart, decimal? ovdEnd, string status);
        M_BUCKET Detail(string code);
        bool Add(M_BUCKET model);
        bool Update(M_BUCKET model, string user, DateTime systemDate);
        bool CheckDuplicate(string code);
    }
}
