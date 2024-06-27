using System;
using System.Collections.Generic;

[Serializable]
public class Vehicle  //todo refactor to base class or interface and improve
{
        public string Name;
        public List<VehicleStat> StatsList;
        public List<VehicleCustomizationModifier> CustomizationModifiers;
}