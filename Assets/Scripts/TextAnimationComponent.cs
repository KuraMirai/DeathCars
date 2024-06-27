using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TextAnimationComponent : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text text;
    [SerializeField] 
    private float typingSpeed = 0.1f;
    
    private string _cachedText;
    
    private void Awake()
    {
        _cachedText = text.text;
        ResetText();
    }

    public void SetAnimationSpeed(float speed)
    {
        typingSpeed = speed;
    }

    public void AnimateText()
    {
        StartCoroutine(AnimationRoutine());
    }

    public void ResetText()
    {
        text.text = String.Empty;
    }

    private IEnumerator AnimationRoutine()
    {
        foreach (char letter in _cachedText)
        {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
