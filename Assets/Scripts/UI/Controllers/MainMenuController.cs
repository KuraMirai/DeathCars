using UI.Interfaces;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class MainMenuController : BaseWindowController, IInitable, IDestroyable
    { 
        [SerializeField] 
        private MainMenuView viewPrefab;

        private MainMenuView _view;

        private void Awake()
        {
            Open();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                if (_view != null)
                {
                    _view.ActivateInteractiveParts(true);
                    _view.SetSelectedElement();
                }
        }

        public void Init()
        {
            _view = Instantiate(viewPrefab, WindowsManager.Instance.MainCanvas.transform);
            _view.StartButton.onClick.AddListener(OnStartButtonClicked);
            _view.VehicleButton.onClick.AddListener(OnVehicleButtonClicked);
            _view.AbilitiesButton.onClick.AddListener(OnAbilitiesButtonClicked);
            _view.TutorialButton.onClick.AddListener(OnTutorialButtonClicked);
            _view.BackButton.onClick.AddListener(OnBackButtonClicked);
        }

        public void Destroy()
        {
            Destroy(_view.gameObject);
            _view = null;
        }

        public override async void Open()
        {
            Init();
            _view.Open();
            await _view.MenuAnimationComponent.PlayOpen();
            _view.PlayIndividualAnimations(true);
            _view.SetSelectedElement();
        }

        public override void Close()
        {
            _view.MenuAnimationComponent.PlayClose();
            _view.Close();
            _view.PlayIndividualAnimations(false);
            Destroy();
        }

        private void OnStartButtonClicked()
        { 
            WindowsManager.Instance.OnOpenWindow<TracksMenuController>();
            WindowsManager.Instance.OnCloseWidow<MainMenuController>();
        }        
        private void OnVehicleButtonClicked()
        {
            WindowsManager.Instance.OnOpenWindow<VehicleMenuController>();
            WindowsManager.Instance.OnCloseWidow<MainMenuController>();
        }        
        private void OnAbilitiesButtonClicked()
        {
            _view.ActivateInteractiveParts(false);
            WindowsManager.Instance.OnOpenWindow<AbilitiesMenuController>();
        }        
        private void OnTutorialButtonClicked()
        {
            Debug.Log("Not implemented");
            /*WindowsManager.Instance.OnOpenWindow(WindowSignalType.Tutorial);
            WindowsManager.Instance.OnCloseWidow(WindowSignalType.MainMenu);*/
        }       
        private void OnBackButtonClicked()
        {
            WindowsManager.Instance.OnCloseWidow();
        }
    }
}