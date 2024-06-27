using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class TrackCardView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] 
        private Image cardBgImage;
        [SerializeField] 
        private Image mapImage;
        [SerializeField] 
        private Image trackImage; 
        [SerializeField] 
        private Image playImage;
        [SerializeField]
        private Text trackNameText;
        [SerializeField] 
        private Text trackTypeText;

        private TrackPreview _data;

        public event Action<TrackPreview> CardClicked; 

        public void Init(TrackPreview data)
        {
            _data = data;
            trackNameText.text = _data.TrackName;
            trackTypeText.text = _data.TrackType;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            CardClicked?.Invoke(_data);
        }
    }
}
