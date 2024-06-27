using System;
using UnityEngine;

namespace UI.Controllers
{
    public class MainMenuAnimationsController : MonoBehaviour
    {
        [SerializeField] private Animator musicLinesAnimator;
        [SerializeField] private Animator carFlaresAnimator;
        [SerializeField] private Animator vehicleInfoAnimator;
        [SerializeField] private TextAnimationComponent[] textsToAnimate;

        private void Awake()
        {
            PlayAllAnimations(false);
        }
        
        public void PlayAllAnimations(bool play)
        {
            musicLinesAnimator.enabled = play;
            carFlaresAnimator.gameObject.SetActive(play);
            carFlaresAnimator.enabled = play;
            vehicleInfoAnimator.Rebind();
            vehicleInfoAnimator.enabled = play;
        }

        public void AnimateAllTexts(bool play)
        {
            foreach (TextAnimationComponent textAnimationComponent in textsToAnimate)
            {
                if (play)
                    textAnimationComponent.AnimateText();
                else
                    textAnimationComponent.ResetText();
            }
        }
    }
}