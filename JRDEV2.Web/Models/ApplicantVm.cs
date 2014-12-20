using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Models
{
    public class ApplicantVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Resume resume { get; set; }

    }
}