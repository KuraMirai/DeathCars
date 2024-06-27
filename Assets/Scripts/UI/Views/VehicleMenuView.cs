using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class VehicleMenuView : BaseView, IUICurrentSelectable
    {
        [SerializeField] private VehicleCustomizationModifierView vehicleCustomizationModifierViewPrefab;
        [SerializeField] private VehicleCustomizationModifierParameterView vehicleCustomizationModifierParameterView;
        [SerializeField] private VehicleStatPanel vehicleStatPanel;
        [SerializeField] private Transform vehicleCustomizationModifiersParent;
        [SerializeField] private Transform vehicleCustomizationModifierParameterViewsParent;
        [SerializeField] private VehicleCustomizationModifierView vehicleSwitcher;
        [SerializeField] private Button confirmButton;
        [SerializeField] private BaseAnimationComponent[] childrenAnimationComponents; 

        private List<VehicleCustomizationModifierView> _instantiatedVehicleCustomizationModifiers =
            new List<VehicleCustomizationModifierView>();

        private Dictionary<VehicleCustomizationModifier, VehicleCustomizationModifierParameterView>
            _instantiatedVehicleCustomizationModifierParameter =
                new Dictionary<VehicleCustomizationModifier, VehicleCustomizationModifierParameterView>();

        public Button ConfirmButton => confirmButton;

        public event Action VehicleSwitcherForwardClicked;
        public event Action VehicleSwitcherBackwardClicked;

        public void Init(Vehicle vehicleData)
        {
            ClearCustomizationModifiersParameters();
            ClearCustomizationModifiers();
            vehicleStatPanel.Init(vehicleData);
            InitCustomizationModifiers(vehicleData.CustomizationModifiers);
            vehicleSwitcher.BackwardClicked += OnVehicleSwitcherBackwardClicked;
            vehicleSwitcher.ForwardClicked += OnVehicleSwitcherForwardClicked;
        }

        public override void Open()
        {
            base.Open();
            foreach (BaseAnimationComponent baseAnimationComponent in childrenAnimationComponents)
            { 
                baseAnimationComponent.PlayOpen();
            }
        }

        public override void Close(bool hide = true)
        {
            foreach (BaseAnimationComponent baseAnimationComponent in childrenAnimationComponents)
            {
                baseAnimationComponent.PlayClose(); //todo make awaitable
            }
            base.Close(hide);
            ClearCustomizationModifiers();
            ClearCustomizationModifiersParameters();
        }

        private void InitCustomizationModifiers(List<VehicleCustomizationModifier> modifiers)
        {
            foreach (VehicleCustomizationModifier customizationModifier in modifiers)
            {
                customizationModifier.ClearSubscriptions();
                VehicleCustomizationModifierView view = Instantiate(vehicleCustomizationModifierViewPrefab,
                    vehicleCustomizationModifiersParent);
                _instantiatedVehicleCustomizationModifiers.Add(view);
                view.Init(customizationModifier.Name);
                view.ForwardClicked += customizationModifier.NextVehicleCustomizationModifierParameter;
                view.BackwardClicked += customizationModifier.PreviousVehicleCustomizationModifierParameter;
                customizationModifier.CollectionIdState += view.CheckHideButtons;
                InitCustomizationModifiersParameter(customizationModifier);
                customizationModifier.InitializationCall();
            }
        }

        private void InitCustomizationModifiersParameter(VehicleCustomizationModifier modifier)
        {
            VehicleCustomizationModifierParameterView view = Instantiate(vehicleCustomizationModifierParameterView,
                vehicleCustomizationModifierParameterViewsParent);
            view.Init(modifier.ParametersList[0]);
            _instantiatedVehicleCustomizationModifierParameter.Add(modifier ,view);
            modifier.VehicleCustomizationModifierParameterValueChanged += view.Init;
        }

        private void ClearCustomizationModifiers()
        {
            if (_instantiatedVehicleCustomizationModifiers.Count == 0)
                return;
            foreach (var t in _instantiatedVehicleCustomizationModifiers)
            {
                Destroy(t.gameObject);
            }

            _instantiatedVehicleCustomizationModifiers.Clear();
        }

        private void ClearCustomizationModifiersParameters()
        {
            if (_instantiatedVehicleCustomizationModifierParameter.Count == 0)
                return;
            foreach (var t in _instantiatedVehicleCustomizationModifierParameter)
            {
                t.Key.VehicleCustomizationModifierParameterValueChanged -= t.Value.Init; 
                Destroy(t.Value.gameObject);
            }

            _instantiatedVehicleCustomizationModifierParameter.Clear();
        }

        private void OnVehicleSwitcherForwardClicked()
        {
            VehicleSwitcherForwardClicked?.Invoke();
        }

        private void OnVehicleSwitcherBackwardClicked()
        {
            VehicleSwitcherBackwardClicked?.Invoke();
        }

        public void SetSelectedElement()
        {
            EventSystem.current.SetSelectedGameObject(_instantiatedVehicleCustomizationModifiers[0].ForwardButton.gameObject);
        }
        
        public void CheckHideButtons(CollectionIdState state)
        {
            vehicleSwitcher.CheckHideButtons(state);
        }
    }
}