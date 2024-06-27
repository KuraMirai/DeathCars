using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class TextAnimationSelectable : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField] 
        protected Animator textAnimator;

        public virtual void OnSelect(BaseEventData eventData)
        {
            textAnimator.enabled = true;
        }

        public virtual void OnDeselect(BaseEventData eventData)
        {
            textAnimator.enabled = false;
            textAnimator.Rebind();
        }
    }
}