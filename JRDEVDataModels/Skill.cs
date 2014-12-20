using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JRDEVDataModels
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<UserSkill> UserSkills { get; set; }
        public virtual List<JobSkill> JobSkills { get; set; }
    }
}
