using JRDEV2.Web.Models;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
    public interface ITalentProfileAdapter
    {
        //TalentProfile GetTalentProfile(string id); Commented out by George W. 4/29/14
        TalentVM GetTalentVM(string id);
        TalentProfile PostNewTalentProfile(TalentVM newTalent);
        TalentProfile PATCHTalentVM(string userID, TalentVM newTalentVM);
        TalentProfile PATCHTalentSettings(int id, string userID, TalentVM newTalentVM);
        TalentProfile DeleteTalentProfile(int id);
    }
}
