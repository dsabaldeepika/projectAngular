using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
   public interface IClickAdapter
    {
       List<Click> GetClicks();
   //    List<Click> GetJobClicks(int id);
       Click GetClick(int id);
       Click PostNewClick(Click newClick);    
       Click PutClick(int id, Click newClick);
       Click DeleteClick(int id);
    }
}
