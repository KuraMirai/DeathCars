using UI.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class TracksMenuView : BaseView, IInitable
    {
        [SerializeField]
        private Button backButton;
        [SerializeField]
        private Image backgroundImage;
        [SerializeField]
        private Text trackName;
        [SerializeField]
        private SnapSelector trackCardsController;


        public SnapSelector TrackCardsController => trackCardsController;
        public Button BackButton => backButton;

        public void Init()
        {
            trackCardsController.Init();
        }

        public void UpdateData(TrackPreview data)
        {
            backgroundImage.sprite = data.MapSprite;
            trackName.text = data.TrackName;
        }
    }
}
