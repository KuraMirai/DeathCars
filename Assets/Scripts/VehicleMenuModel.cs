using System;
using System.Collections.Generic;
using UI;
using UI.Interfaces;
using UnityEngine;

[Serializable]
public class VehicleMenuModel : IInitializationCallable//todo make it not serializable an probably interface or base class
{
    public List<Vehicle> AvaliableVehicles;

    private int _currentVehicleId;

    public event Action<Vehicle> VehicleChanged;
    public event Action<CollectionIdState> CollectionIdState;

    public void InitializationCall()
    {
        _currentVehicleId = 0;
        CollectionIdState?.Invoke(GetCollectionState());
    }
    
    public Vehicle GetCurrentVehicle()
    {
        return AvaliableVehicles[_currentVehicleId];
    }

    public void NextVehicle()
    {
        int oldId = _currentVehicleId;
        _currentVehicleId++;
        _currentVehicleId = Mathf.Clamp(_currentVehicleId,0, AvaliableVehicles.Count - 1);
        if (oldId != _currentVehicleId)
        {
            VehicleChanged?.Invoke(AvaliableVehicles[_currentVehicleId]);
            CollectionIdState?.Invoke(GetCollectionState());
        }
    }  
    public void PreviousVehicle()
    {
        int oldId = _currentVehicleId;
        _currentVehicleId--;
        _currentVehicleId = Mathf.Clamp(_currentVehicleId,0, AvaliableVehicles.Count - 1);
        if(oldId != _currentVehicleId)
        {
            VehicleChanged?.Invoke(AvaliableVehicles[_currentVehicleId]);
            CollectionIdState?.Invoke(GetCollectionState());
        }
    }
    
    public CollectionIdState GetCollectionState()
    {
        if (_currentVehicleId == AvaliableVehicles.Count - 1)
            return UI.CollectionIdState.Last;
        if (_currentVehicleId == 0)
            return UI.CollectionIdState.First;
        return UI.CollectionIdState.Interval;
    }

    public void ClearSubscriptions()
    {
        CollectionIdState = null;
    }
}