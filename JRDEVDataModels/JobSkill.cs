using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public class JobSkill
    {
        public int JobSkillId { get; set; }

        public int SkillId { get; set; }
        [ForeignKey("SkillId"), InverseProperty("JobSkills")]
        public virtual Skill Skill { get; set; }

        public int JobId { get; set; }
        [ForeignKey("JobId"), InverseProperty("JobSkills")]
        public virtual Job Job { get; set; }
    }
}
