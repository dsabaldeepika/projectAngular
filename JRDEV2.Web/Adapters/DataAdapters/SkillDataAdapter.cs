using JRDEV2.Web.Adapters.Interfaces;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class SkillDataAdapter : ISkillAdapter
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Skill> GetSkill()
        {
            List<Skill> model = new List<Skill>();
            model = db.Skills
                            //.Where(j=>j.Hidden == false)
                            .ToList();
            return model;

        }
        public Skill GetSkill(int id)
        {
            Skill model = new Skill();

            model = db.Skills
                           .Where(j => j.SkillId == id)
                           //.Where(j=>j.Hidden == false)
                           .FirstOrDefault();
            return model;
        }

        public Skill PostNewSkill(Skill newSkill)
        {
            Skill skill = new Skill();
            //set variables
            db.Skills.Add(skill);
            db.SaveChanges();

            return newSkill; 
        }

        public Skill PutSkill(int id, Skill newSkill)
        {
            db.Skills.Where(j => j.SkillId == id)
                        //.Where(j=>j.Hidden == false)
                        .FirstOrDefault();
            Skill skill = new Skill();
            //Set Variables
            db.SaveChanges();
            return newSkill;
        }

        public Skill DeleteSkill(int id)
        {
            Skill skill = new Skill();
            skill = db.Skills
                            .Where(j => j.SkillId == id)
                            //.Where(j=>j.Hidden == false)
                            .FirstOrDefault();
            //skill.IsDeleted = true;
            db.SaveChanges();
            return db.Skills.FirstOrDefault();
        }
    }
}