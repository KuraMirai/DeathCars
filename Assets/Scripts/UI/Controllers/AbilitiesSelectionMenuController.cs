using System.Collections.Generic;
using Savings;
using UI.Interfaces;
using UI.Models;
using UI.Views;
using UI.Views.Skills;
using UnityEngine;

namespace UI.Controllers
{
    public class AbilitiesSelectionMenuController : BaseWindowController, IDestroyable
    {
        [SerializeField] private AbilitiesSelectionMenuView viewPrefab;
        [SerializeField] private LoadOutPanelModel loadOutModel;
        [SerializeField] private List<AbilitySkillPreview> abilitiesPreview;
        [SerializeField] private LoadOutsSaveSystem loadOutsSaveSystem;

        private AbilitiesSelectionMenuView _view;
        private bool _skillReplaceState;
        private SkillPreview _tempSkill;
        private AbilitySelectionSkillElement _tempSelectedSkillElement;

        public void Destroy()
        {
            Destroy(_view.gameObject);
            _view = null;
        }

        private void OnLoadOutPageButtonClicked(int id)
        {
            loadOutModel.UpdateCurrentSelectedLoadOut(id);
            _view.UpdateView(loadOutModel.CurrentLoadOut);
        }

        private void OnLoadOutSkillClicked(SkillPreview skill, SkillElement element)
        {
            if (_skillReplaceState)
            {
                loadOutModel.FindAndUpdateSkillData(skill, _tempSkill);
                _view.UpdateView(loadOutModel.CurrentLoadOut);
                _view.OnSkillReplaced(_tempSkill);
                _tempSelectedSkillElement.SetSelected(false);
                _tempSelectedSkillElement = null;
                _skillReplaceState = false;
            }
        }

        private void OnAbilitySelectionSkillClicked(SkillPreview skill, SkillElement element)
        {
            _tempSkill = skill;
            if(_tempSelectedSkillElement != null)
                _tempSelectedSkillElement.SetSelected(false);
            _tempSelectedSkillElement = (AbilitySelectionSkillElement)element;
            _skillReplaceState = true;

            /*WindowsManager.Instance.OnOpenWindow<MainMenuController>();
            WindowsManager.Instance.OnCloseWidow<AbilitiesSelectionMenuController>();*/
        }

        private void OnConfirmButtonClicked()
        {
            WindowsManager.Instance.OnOpenWindow<MainMenuController>();
            WindowsManager.Instance.OnCloseWidow<AbilitiesSelectionMenuController>();
        }

        public override async void Open()
        {
            var data = loadOutsSaveSystem.ForceLoad();
            if (data != null && data.skillsLoadOuts.Count != 0)
            {
                loadOutModel.Init(data);
            }
            _view = Instantiate(viewPrefab, WindowsManager.Instance.MainCanvas.transform);
            _view.Init(loadOutModel, abilitiesPreview);
            _view.ConfirmButton.onClick.AddListener(OnConfirmButtonClicked);
            _view.LoadOutPageButtonClicked += OnLoadOutPageButtonClicked;
            _view.AbilitySelectionSkillClicked += OnAbilitySelectionSkillClicked;
            _view.LoadOutSkillClicked += OnLoadOutSkillClicked;
            _view.Open();
            _view.SetSelectedElement();
        }

        public override void Close()
        {
            _skillReplaceState = false;
            _tempSkill = null;
            _tempSelectedSkillElement = null;
            loadOutsSaveSystem.SetData(new LoadOutsData(loadOutModel));
            loadOutsSaveSystem.ForceSave();
            _view.Close();
            Destroy();
        }
    }
}