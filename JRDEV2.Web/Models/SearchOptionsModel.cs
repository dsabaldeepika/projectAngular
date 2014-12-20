using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Models
{
    public class SearchOptionsModel
    {
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string SearchText { get; set; }
    }
}