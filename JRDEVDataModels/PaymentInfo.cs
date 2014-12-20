using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public class PaymentInfo : AuditObject
    {
        public int PaymentInfoId { get; set; }
        public string PaymentType { get; set; }
        public int CardNumber { get; set; }
        public int AccountNumber { get; set; }
        public string FullName { get; set; }
        public int ExperationDate { get; set; }
        public int SecurityPin { get; set; }

        //Foreign Key

        public int CompanyId { get; set; }
    }
}
