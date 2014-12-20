using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public class TalentProfile : ContactInfo
    {
        public int TalentProfileId { get; set; }
        public int DesiredSalary { get; set; }
        public bool WillRelocate { get; set; }
        public bool CurrentlyLooking { get; set; }
        public bool IsLookingForJob { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }
        public string PicFile { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
