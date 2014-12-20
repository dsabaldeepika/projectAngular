using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Models
{
    public class TalentVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }
        public int DesiredSalary { get; set; }
        public bool WillRelocate { get; set; }
        public bool CurrentlyLooking { get; set; }
        public string MainUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string GoogleplusUrl { get; set; }
        public string PicFile { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddress2 { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
    }
}