using UI.Interfaces;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class VehicleMenuController : BaseWindowController, IInitable, IDestroyable
    {
        [SerializeField] 
        private VehicleMenuView viewPrefab;  
        [SerializeField] 
        private VehicleMenuModel menuModel;

        private VehicleMenuView _view;

        public void Init()
        {
            menuModel.ClearSubscriptions();
            _view = Instantiate(viewPrefab, WindowsManager.Instance.MainCanvas.transform);
            _view.Init(menuModel.GetCurrentVehicle());
            _view.ConfirmButton.onClick.AddListener(OnConfirmButtonClicked);
            _view.VehicleSwitcherForwardClicked += OnVehicleSwitcherForwardClicked;
            _view.VehicleSwitcherBackwardClicked += OnVehicleSwitcherBackwardClicked;
            menuModel.VehicleChanged += _view.Init;
            menuModel.CollectionIdState += _view.CheckHideButtons;
            menuModel.InitializationCall();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                if (_view != null)
                {
                    OnConfirmButtonClicked();
                }
        }

        public void Destroy()
        {
            menuModel.VehicleChanged -= _view.Init;
            Destroy(_view.gameObject);
            _view = null;
        }

        public override async void Open()
        {
            Init();
            _view.Open();
            _view.SetSelectedElement();
        }

        public override void Close()
        {
            _view.Close();
            Destroy();
        }
        
        private void OnConfirmButtonClicked()
        {
            WindowsManager.Instance.OnOpenWindow<MainMenuController>();
            WindowsManager.Instance.OnCloseWidow<VehicleMenuController>();
        }

        private void OnVehicleSwitcherForwardClicked()
        {
            menuModel.NextVehicle();
        }

        private void OnVehicleSwitcherBackwardClicked()
        {
            menuModel.PreviousVehicle();
        }
    }
}