using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCLS.WEB.Entities;

namespace NCLS.WEB.Models.ViewModels.BankrupcyFraudC
{
    public class BankruptcyFraudViewModel
    {
        public T_BANKRUPTCY_FRAUD_D BankruptcyFraudD { get; set; }
        public T_BANKRUPTCY_FRAUD_H BankruptcyFraudH { get; set; }
        public S_CUSTOMER_DETAIL CustomerDetail { get; set; }
        public List<T_BANKRUPTCY_FRAUD_H> ListBankruptcyFraudH { get; set; }
        public string mode { get; set; }

        public BankruptcyFraudViewModel()
        {
            ListBankruptcyFraudH = new List<T_BANKRUPTCY_FRAUD_H>();
            CustomerDetail = new S_CUSTOMER_DETAIL();
            BankruptcyFraudD = new T_BANKRUPTCY_FRAUD_D();
            BankruptcyFraudH = new T_BANKRUPTCY_FRAUD_H();
        }
    }
}