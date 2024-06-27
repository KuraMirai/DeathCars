using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class SoundInfoView : MonoBehaviour
    {
        [SerializeField]
        private Text singerNameText;
        [SerializeField]
        private Text songNameText;
        [SerializeField] 
        private Button playButton;

        public Button PlayButton => playButton;
    }
}
