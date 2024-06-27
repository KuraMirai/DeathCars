using System;
using UI.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.Skills
{
    public class AbilitySelectionSkillElement : SkillElement, ILockable
    {
        [SerializeField] 
        private Image lockedImage; 
        [SerializeField] 
        private Image selectedImage;

        private bool _locked;

        public bool Locked => _locked;
        public event Action LockStateChanged;

        public void Init(AbilitySkillPreview data)
        {
            base.Init(data);
            _locked = data.Locked;
            InitLockUnlockView();
        }

        protected override void OnButtonClick()
        {
            if(_locked)
                return;
            base.OnButtonClick();
            SetSelected(true);
        }

        public void SetSelected(bool selected)
        {
            selectedImage.gameObject.SetActive(selected);
        }

        public void InitLockUnlockView()
        {
            SetLockUnlockView();
        }

        public void LockUnlock(bool state)
        {
            _locked = state;
            SetLockUnlockView();
        }

        public void SetLockUnlockView()
        {
            lockedImage.gameObject.SetActive(_locked);
        }
    }
}
