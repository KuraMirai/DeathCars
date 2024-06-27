using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class LevelProgressView : MonoBehaviour
    {
        [SerializeField] 
        private Text levelText;
        [SerializeField] 
        private Slider levelTexSlider;
        [SerializeField] 
        private Text professionText;
        [SerializeField] 
        private Image levelBgImage;
        [SerializeField] 
        private Image sliderBgImage; 
        [SerializeField] 
        private Image sliderFillImage;
        [SerializeField] 
        private Image bottomImage; 
        [SerializeField] 
        private List<LevelSprites> levelSprites;

        private void OnValidate()
        {
            foreach (LevelSprites levelSprite in levelSprites)
            {
                levelSprite.imageObjectOnScene.sprite = levelSprite.propertySprite;
            }
        }
    }

    [Serializable]
    public class LevelSprites
    {
        public Image imageObjectOnScene;
        public Sprite propertySprite;
    }
}
