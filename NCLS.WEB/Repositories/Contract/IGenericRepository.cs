using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCLS.WEB.Repositories.Contract
{
    public interface IGenericRepository<T> where T : class 
    {
        void Add(T model);
        void CheckDuplicate(string code);       
    }
}
