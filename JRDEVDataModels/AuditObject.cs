using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public abstract class AuditObject
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        
        [Required]
        public string UserCreatedId { get; set; }
        [ForeignKey("UserCreatedId")]
        public virtual User UserCreated { get; set; }
        
        [Required]
        public string UserUpdatedId { get; set; }
        [ForeignKey("UserUpdatedId")]
        public virtual User UserUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
