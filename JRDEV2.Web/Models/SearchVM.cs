using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Models
{
    public class SearchVM
    {
       public List<JobVM> JobVM { get; set; }
       public List<CompanyVM> CompanyVM { get; set; }

    }
}