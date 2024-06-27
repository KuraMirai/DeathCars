using UnityEngine;

namespace Extensions
{
    public static class CanvasGroupExtension
    {
        public static void SetActive(this CanvasGroup canvasGroup, bool activate)
        {
            canvasGroup.alpha = activate ? 1 : 0;
            canvasGroup.interactable = activate;
            canvasGroup.blocksRaycasts = activate;
        }
    }
}

