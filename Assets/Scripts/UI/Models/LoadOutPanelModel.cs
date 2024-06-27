using System;
using System.Collections.Generic;
using Savings;
using UI.Controllers;

namespace UI.Models
{
    [Serializable]
    public class LoadOutPanelModel
    {
        private int _currentSelectedLoadOutId;
        public List<SkillsLoadOut> skillsLoadOuts; //todo make private

        public List<SkillsLoadOut> SkillsLoadOuts => skillsLoadOuts;
        
        public int CurrentSelectedLoadOutId => _currentSelectedLoadOutId;

        public SkillsLoadOut CurrentLoadOut => skillsLoadOuts[_currentSelectedLoadOutId];

        public void Init(LoadOutsData data)
        {
            skillsLoadOuts = data.skillsLoadOuts;
        }

        public void UpdateCurrentSelectedLoadOut(int id)
        {
            _currentSelectedLoadOutId = id;
        }

        public void FindAndUpdateSkillData(SkillPreview skillPreview, SkillPreview replaceSkill)
        {
            skillsLoadOuts[_currentSelectedLoadOutId].FindAndReplaceSkill(skillPreview, replaceSkill);
        }
    }
}