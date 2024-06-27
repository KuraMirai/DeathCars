using System;
using System.Collections.Generic;
using UI.Controllers;
using UI.Views.Skills;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoadOutPanel : MonoBehaviour
    {
        [SerializeField] 
        private SkillElement skillPrefab;
        [SerializeField] 
        private Transform skillsContainerTransform;
        [SerializeField]
        private Text averageText;
        [SerializeField]
        private List<Button> loadOutButtons;

        public event Action<int> LoadOutPageButtonClicked; 
        private List<SkillElement> _instantiatedElements = new List<SkillElement>();
        
        public void Init(SkillsLoadOut data, Action<SkillPreview, SkillElement> skillClickedCallback, Action<SkillPreview> skillHoveredCallback)
        {
            foreach (SkillPreview skillPreview in data.Skills)
            {
                SkillElement skill = Instantiate(skillPrefab, skillsContainerTransform,false);
                skill.Init(skillPreview);
                _instantiatedElements.Add(skill);
                skill.SkillClicked += skillClickedCallback;
                skill.SkillHovered += skillHoveredCallback;
            }

            InitLoadOutButtons();
            UpdateManaIndicator(data.GetAverageMana());
        }

        private void InitLoadOutButtons()
        {
            for (int i = 0; i < loadOutButtons.Count; i++)
            {
                int id = i;
                Button loadOutButton = loadOutButtons[i];
                loadOutButton.onClick.AddListener(() => OnButtonClicked(id));
            }
        }

        private void OnButtonClicked(int id)
        {
            LoadOutPageButtonClicked?.Invoke(id);
        }

        public void UpdateSkillsView(SkillsLoadOut data)
        {
            for (int i = 0; i < _instantiatedElements.Count; i++)
            {
                SkillElement skillElement = _instantiatedElements[i];
                skillElement.Init(data.Skills[i]);
            }
            UpdateManaIndicator(data.GetAverageMana());
        }

        public GameObject GetFirstSkill()
        {
            return _instantiatedElements[0].gameObject;
        }

        private void UpdateManaIndicator(float average)
        {
            averageText.text = average.ToString();
        }
    }
}
