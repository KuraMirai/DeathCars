using UI.Controllers;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoWidget : MonoBehaviour
{
    [SerializeField] private Text skillNameText;
    [SerializeField] private Text skillDescriptionText;
    [SerializeField] private Text skillTypeText;
    [SerializeField] private Text manaAmountText;
    [SerializeField] private Image skillImage;

    public void Init(SkillPreview skill)
    {
        UpdateInfo(skill);
    }

    public void UpdateInfo(SkillPreview skill)
    {
        skillNameText.text = skill.Name;
        skillDescriptionText.text = skill.Description;
        skillTypeText.text = skill.Type;
        manaAmountText.text = skill.ManaAmount.ToString();
    }
}