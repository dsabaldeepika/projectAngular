using JRDEV2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
    interface ISearchAdapter
    {
        SearchVM search(string query);

    }
}
