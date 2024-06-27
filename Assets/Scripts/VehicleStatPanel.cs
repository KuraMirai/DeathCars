using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleStatPanel : MonoBehaviour
{
    [SerializeField] private Text vehicleNameText;
    [SerializeField] private Transform vehicleStatsViewsParent;
    [SerializeField] private VehicleStatView vehicleStatViewPrefab;

    private List<VehicleStatView> _instantiatedStats = new List<VehicleStatView>();
    
    public void Init(Vehicle vehicleData)
    {
        vehicleNameText.text = vehicleData.Name;
        Clear();
        foreach (VehicleStat vehicleStat in vehicleData.StatsList)
        {
            VehicleStatView view = Instantiate(vehicleStatViewPrefab, vehicleStatsViewsParent);
            _instantiatedStats.Add(view);
            view.Init(vehicleStat);
        }
    }

    private void Clear()
    {
        if(_instantiatedStats.Count == 0)
            return;
        foreach (var t in _instantiatedStats)
        {
            Destroy(t.gameObject);
        }
        
        _instantiatedStats.Clear();
    }
}