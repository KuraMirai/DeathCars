using System;
using System.Collections.Generic;
using UI.Controllers;
using UI.Models;
using UI.Views.Skills;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class AbilitiesSelectionMenuView : BaseView, IUICurrentSelectable
    {
        [SerializeField] 
        private LoadOutPanel loadOutPanel;
        [SerializeField] 
        private AbilitiesSelectionPanel abilitiesSelectionPanelPanel;
        [SerializeField]
        private SkillInfoWidget skillInfoWidget;
        [SerializeField]
        private Button confirmButton;        
        [SerializeField] protected BaseAnimationComponent[] childrenAnimationComponents;

        public Button ConfirmButton => confirmButton;
        public event Action<int> LoadOutPageButtonClicked; 
        public event Action<SkillPreview, SkillElement> AbilitySelectionSkillClicked; 
        public event Action<SkillPreview, SkillElement> LoadOutSkillClicked; 

        public void Init(LoadOutPanelModel loadOutPreview, List<AbilitySkillPreview> abilitiesPreview)
        {
            SkillsLoadOut loadOut = loadOutPreview.CurrentLoadOut;
            loadOutPanel.Init(loadOut, OnLoadOutSkillClicked, OnSkillHovered);
            loadOutPanel.LoadOutPageButtonClicked += OnLoadOutPageButtonClicked;
            abilitiesSelectionPanelPanel.Init(abilitiesPreview, OnAbilitySelectionSkillClicked, OnSkillHovered);
            skillInfoWidget.Init(loadOut.Skills[0]);
        }

        public override void Open()
        {
            foreach (BaseAnimationComponent baseAnimationComponent in childrenAnimationComponents)
            {
                baseAnimationComponent.PlayOpen();
            }
            base.Open();
        }

        public override void Close(bool hide = true)
        {
            base.Close(hide);
            foreach (BaseAnimationComponent baseAnimationComponent in childrenAnimationComponents)
            {
                baseAnimationComponent.PlayClose(); //todo make awaitable
            }
        }

        public void UpdateView(SkillsLoadOut data)
        {
            loadOutPanel.UpdateSkillsView(data);
        }

        public void OnLoadOutPageButtonClicked(int id)
        {
            LoadOutPageButtonClicked?.Invoke(id);
        }

        private void OnLoadOutSkillClicked(SkillPreview data, SkillElement element)
        {
            LoadOutSkillClicked?.Invoke(data, element);
        }
        
        private void OnAbilitySelectionSkillClicked(SkillPreview data, SkillElement element)
        {
            AbilitySelectionSkillClicked?.Invoke(data, element);
        }

        private void OnSkillHovered(SkillPreview data)
        {
            skillInfoWidget.UpdateInfo(data);
        }
        
        public void OnSkillReplaced(SkillPreview data)
        {
            skillInfoWidget.UpdateInfo(data);
        }

        public void SetSelectedElement()
        {
            EventSystem.current.SetSelectedGameObject(loadOutPanel.GetFirstSkill());
        }
    }
}
