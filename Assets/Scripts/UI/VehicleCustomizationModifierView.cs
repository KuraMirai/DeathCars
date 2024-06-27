using System;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class VehicleCustomizationModifierView : MonoBehaviour
    {
        [SerializeField] 
        private Text nameText;
        [SerializeField] 
        private Button forwardButton;
        [SerializeField]
        private Button backwardButton;
        [SerializeField] 
        private CanvasGroup forwardButtonCanvasGroup;
        [SerializeField] 
        private CanvasGroup backwardButtonCanvasGroup;

        public event Action ForwardClicked;
        public event Action BackwardClicked;
        public Button ForwardButton => forwardButton;
        
        private void Awake()
        {
            forwardButton.onClick.AddListener(OnForwardButtonClicked);
            backwardButton.onClick.AddListener(OnBackwardButtonClicked);
        }

        public void Init(string modificatorName)
        {
            nameText.text = modificatorName;
        }

        private void OnForwardButtonClicked()
        {
            ForwardClicked?.Invoke();
        }        
        
        private void OnBackwardButtonClicked()
        {
            BackwardClicked?.Invoke();
        }

        public void CheckHideButtons(CollectionIdState state)
        {
            if (state == CollectionIdState.First)
            {
                backwardButtonCanvasGroup.SetActive(false);
                forwardButtonCanvasGroup.SetActive(true);
            }

            if (state == CollectionIdState.Last)
            {
                forwardButtonCanvasGroup.SetActive(false);
                backwardButtonCanvasGroup.SetActive(true);
            }
        }
    }
}