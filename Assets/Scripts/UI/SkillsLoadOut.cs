using System;
using System.Collections.Generic;
using UI.Controllers;

namespace UI
{
    [Serializable]
    public class SkillsLoadOut
    {
        public List<SkillPreview> skills;

        public List<SkillPreview> Skills => skills;

        public float GetAverageMana()
        {
            float result = 0;
            foreach (SkillPreview skill in skills)
            {
                result += skill.ManaAmount;
            }

            return result / 2;
        }

        public bool FindAndReplaceSkill(SkillPreview skillPreview, SkillPreview replaceSkill)
        {
            for (var i = 0; i < skills.Count; i++)
            {
                if (skillPreview.Equals(skills[i]))
                {
                    skills[i] = replaceSkill;
                    return true;
                }
            }

            return false;
        }
    }
}