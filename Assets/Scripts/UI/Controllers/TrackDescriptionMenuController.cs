using UI.Interfaces;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class TrackDescriptionMenuController : BaseWindowController, IDestroyable
    { 
        [SerializeField]
        private TrackDescriptionMenuView viewPrefab;

        private TrackDescriptionMenuView _view;

        
        public void Initialize(TrackPreview data)
        {
            _view = Instantiate(viewPrefab, WindowsManager.Instance.MainCanvas.transform);
            _view.Init(data);
            _view.BackButton.onClick.AddListener(OnBackButtonClicked);
        }

        public void Destroy()
        {
            Destroy(_view.gameObject);
            _view = null;
        }

        public override async void Open()
        {
            _view.Open();
            _view.SetSelectedElement();
        }

        public override void Close()
        {
            _view.Close(false);
            Destroy();
        }

        private void OnBackButtonClicked()
        {
            WindowsManager.Instance.OnOpenWindow<TracksMenuController>();
            WindowsManager.Instance.OnCloseWidow<TrackDescriptionMenuController>();
        }
    }
}