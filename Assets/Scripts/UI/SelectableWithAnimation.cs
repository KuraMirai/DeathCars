using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class SelectableWithAnimation : TextAnimationSelectable
    {
        [SerializeField] 
        private Animator buttonAnimator;

        private void Awake()
        {
            OnDeselect(null);
        }

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
            buttonAnimator.enabled = true;
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
            buttonAnimator.enabled = false;
            buttonAnimator.Rebind();
        }
        
    }
}
