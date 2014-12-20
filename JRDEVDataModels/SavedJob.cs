using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public class SavedJob// : AuditObject
    {
        public int SavedJobId { get; set; }
       // public byte StatusId { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
    }
}
