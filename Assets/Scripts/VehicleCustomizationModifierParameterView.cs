using UnityEngine;
using UnityEngine.UI;

public class VehicleCustomizationModifierParameterView : MonoBehaviour
{
    [SerializeField]
    private Text parameterNameText;
    [SerializeField]
    private Text parameterTypeText;

    public void Init(VehicleCustomizationModifierParameter parameter)
    {
        parameterNameText.text = parameter.Name;
        parameterTypeText.text = parameter.TypeName;
    }
}