using System;
using UI.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views.Skills
{
    public class SkillElement : MonoBehaviour, IPointerEnterHandler, ISelectHandler
    {
        [SerializeField] 
        private Image bgImage;
        [SerializeField]
        private Image skillImage;
        [SerializeField]
        private Text manaAmountText;
        [SerializeField] 
        protected Button selfButton;

        private SkillPreview _data;
        
        public event Action<SkillPreview, SkillElement> SkillClicked;
        public event Action<SkillPreview> SkillHovered;

        public void Init(SkillPreview data)
        {
            _data = data;
            manaAmountText.text = _data.ManaAmount.ToString();
            selfButton.onClick.AddListener(OnButtonClick);
        }

        protected virtual void OnButtonClick()
        {
            SkillClicked?.Invoke(_data, this);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            SkillHovered?.Invoke(_data);
        }

        public void OnSelect(BaseEventData eventData)
        {
            SkillHovered?.Invoke(_data);
        }
    }
}
