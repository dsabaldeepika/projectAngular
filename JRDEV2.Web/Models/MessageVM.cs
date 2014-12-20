using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Models
{
    public class MessageVM
    {
        public int MessageId { get; set; }
        public string ToId { get; set; }
        public string From { get; set; }
        public string FromId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateRead { get; set; }
    }
}