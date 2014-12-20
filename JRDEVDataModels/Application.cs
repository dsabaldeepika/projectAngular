using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public class Application : AuditObject
    {
        public int ApplicationId { get; set; }
        public byte StatusId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual List<Note> Notes { get; set; }

        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int ResumeId { get; set; }
        [ForeignKey("ResumeId")]
        public virtual Resume Resume { get; set; }
    }
}
