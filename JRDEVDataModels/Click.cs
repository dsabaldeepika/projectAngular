using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
   public class Click : AuditObject
   {
       public int ClickId { get; set; }

       public string ClickeeId { get; set; }
       [ForeignKey("ClickeeId")]
       public virtual User Clickee { get; set; }

       [Required]
       public string ClickerId { get; set; }
       [ForeignKey("ClickerId")]
       public virtual User Clicker { get; set; }

       public int? JobId { get; set; }
       [ForeignKey("JobId")]
       public virtual Job Job { get; set; }

       public string IpAddress { get; set; }
       
   }
}
