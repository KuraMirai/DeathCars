using System;

namespace UI.Controllers
{
    [Serializable]
    public class SkillPreview   //todo: remove it when preview ends
    {
        public string Name;
        public string Description;
        public string Type;
        public int ManaAmount;
    }

    [Serializable]
    public class AbilitySkillPreview : SkillPreview
    {
        public bool Locked;
    }
}