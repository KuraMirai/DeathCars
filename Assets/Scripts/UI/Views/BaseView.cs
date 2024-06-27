using Extensions;
using UnityEngine;

namespace UI.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BaseView : MonoBehaviour
    {
        [SerializeField] 
        private CanvasGroup canvasGroup; 
        [SerializeField] 
        private BaseAnimationComponent menuAnimationComponent;

        public BaseAnimationComponent MenuAnimationComponent => menuAnimationComponent;

        public virtual void Open()
        {
            canvasGroup.SetActive(true);
        } 
        public virtual void Close(bool hide = true)
        {
            canvasGroup.SetActive(hide);
        }
    }
}
