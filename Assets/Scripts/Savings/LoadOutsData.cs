using System;
using System.Collections.Generic;
using UI;
using UI.Models;

namespace Savings
{
    [Serializable]
    public class LoadOutsData
    {
        public List<SkillsLoadOut> skillsLoadOuts;

        public LoadOutsData(LoadOutPanelModel data)
        {
            skillsLoadOuts = data.skillsLoadOuts;
        }
    }
}