using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public class Application
    {
        public int applicationId { get; set; }
        public int userId { get; set; }
        public int JobId { get; set; }
        public int ResumeId { get; set; }
        public DateTime dateCreated { get; set; }

        //referenced info
        public string status { get; set; }

        //info to display
        public string content { get; set; }

        public virtual List<Note> notes { get; set; } //for employers
    }
}
