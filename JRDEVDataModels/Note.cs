using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace JRDEVDataModels
{
    public class Note : AuditObject
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }
    }
}
