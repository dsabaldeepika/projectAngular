using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
    public interface ISkillAdapter
    {
        List<Skill> GetSkill();
        Skill GetSkill(int id);
        Skill PostNewSkill(Skill newSkill);
        Skill PutSkill(int id, Skill newSkill);
        Skill DeleteSkill(int id);
    }
}
