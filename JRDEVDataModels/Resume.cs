using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public class Resume : AuditObject
    {
        public int ResumeId { get; set; }
        public string Heading { get; set; }
        public string Summary { get; set; }
        public string WorkExperience { get; set; }
        public string Education { get; set; }
        public string OtherInfo { get; set; }
        
        //foreign key
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
