using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public class UserSkill
    {
        public int UserSkillId { get; set; }

        public int SkillId { get; set; }
        [ForeignKey("SkillId"), InverseProperty("UserSkills")]
        public virtual Skill Skill { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId"), InverseProperty("UserSkills")]
        public virtual User User { get; set; }        
    }
}
