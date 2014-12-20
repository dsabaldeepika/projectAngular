using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public class Company : ContactInfo
    {
        public int CompanyId { get; set; }
        public bool IsVerified { get; set; }
        public bool IsVisible { get; set; }
        public decimal JobPostingBudget { get; set; }
        public decimal CostPerClick { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

        [InverseProperty("Company")]
        public virtual List<User> CompanyUsers { get; set; }
        [InverseProperty("Company")]
        public virtual List<Job> Jobs { get; set; }
        [InverseProperty("Company")]
        public virtual List<Message> Messages { get; set; }

        [Required]
        public string CompanyAdminId { get; set; }
        [ForeignKey("CompanyAdminId")]
        public virtual User CompanyAdmin { get; set; }

        //public string CompanyName { get; set; }
        //public string PaymentInfo { get; set; }
        //public virtual List<PaymentInfo> Payment {get;set;} 
    }
}
