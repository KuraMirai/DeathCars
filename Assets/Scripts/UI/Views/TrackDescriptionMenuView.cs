using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class TrackDescriptionMenuView : BaseView, IUICurrentSelectable
    {
        [SerializeField] private Text trackNameText;
        [SerializeField] private Text trackTypeText;
        [SerializeField] private Text abilitiesDeckText;
        [SerializeField] private Text lapsText;
        [SerializeField] private Text racersCountText;
        [SerializeField] private Text trapsText;
        [SerializeField] private Text deathsAIText;
        [SerializeField] private Text deathsPlayerText;
        [SerializeField] private Button backButton;
        [SerializeField] private Button startButton;
        [SerializeField] private Button editButton;
        [SerializeField] private Image bgImage;

        public Button BackButton => backButton;
        public Button StartButton => startButton;
        public Button EditButton => editButton;
        
        public void Init(TrackPreview data)
        {
            trackNameText.text = data.TrackName;
            trackTypeText.text = data.TrackType;
            abilitiesDeckText.text = data.AbilityDeck;
            lapsText.text = data.Laps.ToString();
            racersCountText.text = data.RacersCount.ToString();
            trapsText.text = data.Traps;
            deathsAIText.text = data.DeathsAI;
            deathsPlayerText.text = data.DeathsPlayer;
            bgImage.sprite = data.MapSprite;
        }

        public void SetSelectedElement()
        {
            EventSystem.current.SetSelectedGameObject(BackButton.gameObject);
        }
    }
}