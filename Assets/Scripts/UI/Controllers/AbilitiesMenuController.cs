using System.Collections.Generic;
using UI.Interfaces;
using UI.Views;
using UI.Views.Skills;
using UnityEngine;

namespace UI.Controllers
{
    public class AbilitiesMenuController : BaseWindowController, IInitable, IDestroyable
    { 
        [SerializeField] 
        private AbilitiesMenuView viewPrefab;
        [SerializeField] 
        private List<SkillPreview> skillPreviews;

        private AbilitiesMenuView _view;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                if (_view != null)
                {
                    Close();
                }
        }
        
        public void Init()
        {
            _view = Instantiate(viewPrefab, WindowsManager.Instance.MainCanvas.transform);
            _view.Init(skillPreviews, OnSkillClicked);
        }

        public void Destroy()
        {
            Destroy(_view.gameObject);
            _view = null;
        }

        public override async void Open()
        {
            Init();
            _view.SetSelectedElement();
            _view.Open();
            await _view.MenuAnimationComponent.PlayOpen();
        }

        public override void Close()
        {
            _view.MenuAnimationComponent.PlayClose();
            Destroy();
        }

        private void OnSkillClicked(SkillPreview data, SkillElement element)
        {
            WindowsManager.Instance.OnOpenWindow<AbilitiesSelectionMenuController>();
            WindowsManager.Instance.OnCloseWidow<AbilitiesMenuController>();
            WindowsManager.Instance.OnCloseWidow<MainMenuController>();
        }
    }
}