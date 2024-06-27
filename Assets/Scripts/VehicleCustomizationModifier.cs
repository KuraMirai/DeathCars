using System;
using System.Collections.Generic;
using UI;
using UI.Interfaces;
using UnityEngine;

[Serializable]
public class VehicleCustomizationModifier : IInitializationCallable   //todo refactor to interface or base class or even remove
{
    public string Name;
    public List<VehicleCustomizationModifierParameter> ParametersList;
    
    private int _currentVehicleCustomizationModifierParameterId;
    public event Action<VehicleCustomizationModifierParameter> VehicleCustomizationModifierParameterValueChanged;
    public event Action<CollectionIdState> CollectionIdState;  
    
    public void InitializationCall()
    {
        _currentVehicleCustomizationModifierParameterId = 0;
        CollectionIdState?.Invoke(GetCollectionState());
    }

    public void NextVehicleCustomizationModifierParameter()
    {
        _currentVehicleCustomizationModifierParameterId++;
        _currentVehicleCustomizationModifierParameterId = Mathf.Clamp(_currentVehicleCustomizationModifierParameterId,0, ParametersList.Count - 1);
        VehicleCustomizationModifierParameterValueChanged?.Invoke(ParametersList[_currentVehicleCustomizationModifierParameterId]);
        CollectionIdState?.Invoke(GetCollectionState());
    }  
    public void PreviousVehicleCustomizationModifierParameter()
    {
        _currentVehicleCustomizationModifierParameterId--;
        _currentVehicleCustomizationModifierParameterId = Mathf.Clamp(_currentVehicleCustomizationModifierParameterId,0, ParametersList.Count - 1);
        VehicleCustomizationModifierParameterValueChanged?.Invoke(ParametersList[_currentVehicleCustomizationModifierParameterId]);
        CollectionIdState?.Invoke(GetCollectionState());
    }

    public CollectionIdState GetCollectionState()
    {
        if (_currentVehicleCustomizationModifierParameterId == ParametersList.Count - 1)
            return UI.CollectionIdState.Last;
        if (_currentVehicleCustomizationModifierParameterId == 0)
            return UI.CollectionIdState.First;
        return UI.CollectionIdState.Interval;
    }

    public void ClearSubscriptions()
    {
        CollectionIdState = null;
    }
}