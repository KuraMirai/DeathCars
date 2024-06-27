using UnityEngine;
using UnityEngine.UI;

public class VehicleStatView : MonoBehaviour
{
    [SerializeField] 
    private Text statNameText;
    [SerializeField] 
    private Text statValueText;
    [SerializeField] 
    private Slider statSlider;

    public void Init(VehicleStat statsData)
    {
        statNameText.text = statsData.StatName;
        statValueText.text = statsData.StatValue.ToString();
        statSlider.maxValue = statsData.StatMaxValue;
        statSlider.value = statsData.StatValue;
    }
}