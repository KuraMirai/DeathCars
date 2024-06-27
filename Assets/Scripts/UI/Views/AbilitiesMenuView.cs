using System;
using System.Collections.Generic;
using UI.Controllers;
using UI.Views.Skills;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Views
{
    public class AbilitiesMenuView : BaseView, IUICurrentSelectable
    {
        [SerializeField] 
        private SkillElement skillPrefab;
        [SerializeField] 
        private Transform skillsContainerTransform;

        private SkillElement[] _skills; 
        
        public void Init(List<SkillPreview> data, Action<SkillPreview, SkillElement> skillClickedCallback)
        {
            _skills = new SkillElement[data.Count];
            for (var i = 0; i < data.Count; i++)
            {
                var skillPreview = data[i];
                SkillElement skill = Instantiate(skillPrefab, skillsContainerTransform, false);
                skill.Init(skillPreview);
                skill.SkillClicked += skillClickedCallback;
                _skills[i] = skill;
            }
        }
        
        public void SetSelectedElement()
        {
            EventSystem.current.SetSelectedGameObject(_skills[0].gameObject);
        }
    }
}
