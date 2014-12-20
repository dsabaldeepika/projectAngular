using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace JRDEVDataModels
{
    public class JobTimeStamp : AuditObject
    {
        public int JobTimeStampId { get; set; }

        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
