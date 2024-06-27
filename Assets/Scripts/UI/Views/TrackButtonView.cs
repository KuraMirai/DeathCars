using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class TrackButtonView : SelectableWithAnimation
    {
        [SerializeField] 
        private Button selfButton;
        [SerializeField]
        private Text[] trackNameText;

        private TrackPreview _data;

        public event Action<TrackPreview> ButtonClicked; 
        public event Action<TrackPreview> ButtonSelected; 

        public void Init(TrackPreview data)
        {
            _data = data;
            foreach (Text text in trackNameText)
            {
                text.text = _data.TrackName;
            }
            selfButton.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            ButtonClicked?.Invoke(_data);
        }

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
            ButtonSelected?.Invoke(_data);
        }
    }
}
