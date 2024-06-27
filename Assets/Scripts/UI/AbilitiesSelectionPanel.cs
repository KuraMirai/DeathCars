using System;
using System.Collections.Generic;
using UI.Controllers;
using UI.Views.Skills;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AbilitiesSelectionPanel : MonoBehaviour
    {
        [SerializeField] 
        private AbilitySelectionSkillElement skillPrefab;
        [SerializeField] 
        private Transform skillsContainerTransform;
        [SerializeField] 
        private Text unlockedValuesText;

        private readonly string UnlockedValuesFormat = "{0} / {1}"; 
        private List<AbilitySelectionSkillElement> _instantiatedElements = new List<AbilitySelectionSkillElement>();
    
        public void Init(List<AbilitySkillPreview> data, Action<SkillPreview, SkillElement> skillClickedCallback, Action<SkillPreview> skillHoveredCallback)
        {
            foreach (AbilitySkillPreview skillPreview in data)
            {
                AbilitySelectionSkillElement skill = Instantiate(skillPrefab, skillsContainerTransform,false);
                _instantiatedElements.Add(skill);
                skill.Init(skillPreview);
                skill.SkillClicked += skillClickedCallback;
                skill.SkillHovered += skillHoveredCallback;
                skill.LockStateChanged += UpdateUnlocked;
            }

            UpdateUnlocked();
        }

        private void UpdateUnlocked()
        {
            int unlockedCount = 0;
            foreach (AbilitySelectionSkillElement element in _instantiatedElements)
            {
                if (element.Locked)
                    unlockedCount++;
            }
            
            unlockedValuesText.text = String.Format(UnlockedValuesFormat, unlockedCount, _instantiatedElements.Count);
        }
    }
}
