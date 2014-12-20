using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Models
{
    public class CompanyVM
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public string MainUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string GoogleplusUrl { get; set; }
        public string Logo { get; set; }
        public string CompanyUserEmail { get; set; }
        public string CompanyUserEmail2 { get; set; }
        public bool IsVerified { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDeleted { get; set; }
    }
}