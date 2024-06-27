using UI.Interfaces;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class TracksMenuController : BaseWindowController, IInitable, IDestroyable
    {
        [SerializeField]
        private TrackDescriptionMenuController trackDescriptionMenuController; 
        [SerializeField] 
        private TracksMenuView viewPrefab;

        private TracksMenuView _view;
        private int _lastSelectedMapId;

        public void Init()
        {
            _view = Instantiate(viewPrefab, WindowsManager.Instance.MainCanvas.transform);
            _view.Init();
            _view.BackButton.onClick.AddListener(OnBackButtonClicked);
            _view.TrackCardsController.ButtonClicked += OnButtonClicked;
            _view.TrackCardsController.ButtonSelected += OnButtonSelected;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                if (_view != null)
                {
                    OnBackButtonClicked();
                }
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
            _view.TrackCardsController.SetSelectedElement(_lastSelectedMapId);
            await _view.MenuAnimationComponent.PlayOpen();
        }

        public override void Close()
        {
            _view.MenuAnimationComponent.PlayClose();
            _view.Close();
            Destroy();
        }
        
        private void OnBackButtonClicked()
        {
            WindowsManager.Instance.OnOpenWindow<MainMenuController>();
            WindowsManager.Instance.OnCloseWidow<TracksMenuController>();
        }

        private void OnButtonClicked(TrackPreview data)
        {
            trackDescriptionMenuController.Initialize(data);
            _lastSelectedMapId = _view.TrackCardsController.GetLastClickedItemId(data);
            WindowsManager.Instance.OnCloseWidow<TracksMenuController>();
            WindowsManager.Instance.OnOpenWindow<TrackDescriptionMenuController>();
        }

        private void OnButtonSelected(TrackPreview data)
        {
            _view.UpdateData(data);
        }
    }
}