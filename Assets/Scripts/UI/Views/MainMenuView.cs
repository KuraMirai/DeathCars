using UI.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class MainMenuView : BaseView, IUICurrentSelectable
    {
        [SerializeField] 
        private LevelProgressView levelProgressView;
        [SerializeField] 
        private SoundInfoView soundInfo;
        [SerializeField] 
        private Button startButton;
        [SerializeField]
        private Button vehicleButton;
        [SerializeField]
        private Button abilitiesButton;
        [SerializeField]
        private Button tutorialButton;
        [SerializeField]
        private Button backButton;
        [SerializeField] 
        private MainMenuAnimationsController mainMenuAnimationsController;
        [SerializeField] 
        private Button[] interactiveButtonsParts;

        public Button StartButton => startButton;
        public Button VehicleButton => vehicleButton;
        public Button AbilitiesButton => abilitiesButton;
        public Button TutorialButton => tutorialButton;
        public Button BackButton => backButton;
       
        public void SetSelectedElement()
        {
            EventSystem.current.SetSelectedGameObject(BackButton.gameObject);
        }

        public void PlayIndividualAnimations(bool play)
        {
            mainMenuAnimationsController.PlayAllAnimations(play);
            mainMenuAnimationsController.AnimateAllTexts(play);
        }
        
        public void ActivateInteractiveParts(bool activate)
        {
            foreach (Button part in interactiveButtonsParts)
            {
                part.interactable = activate;
            }
        }
    }
}
