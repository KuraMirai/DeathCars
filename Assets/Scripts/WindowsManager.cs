using System.Collections.Generic;
using System.Linq;
using UI.Controllers;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] private List<BaseWindowController> windowControllers;
    [SerializeField] private Canvas mainCanvas;

    private static WindowsManagerModel _model;

    private static WindowsManager _windowsManager;

    public Canvas MainCanvas => mainCanvas;
    
    public static WindowsManager Instance
    {
        get
        {
            if (_windowsManager == null)
            {
                _windowsManager = FindObjectOfType<WindowsManager>();
                Initialize();
            }

            return _windowsManager;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instance.OnOpenWindow<AbilitiesMenuController>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instance.OnOpenWindow<TrackDescriptionMenuController>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instance.OnCloseWidow<AbilitiesMenuController>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instance.OnCloseWidow<TrackDescriptionMenuController>();
        }
    }

    private static void Initialize()
    {
        _model = new WindowsManagerModel();
    }

    public void OnOpenWindow<T>() where T : BaseWindowController
    {
        var window = windowControllers.FirstOrDefault(w => w is T);
        if (window == null)
            return;
        _model.AddOpenedWindow(window);
        window.Open();
    }

    public void OnCloseWidow<T>()
    {
        var window = windowControllers.FirstOrDefault(w => w is T);
        if (window == null)
            return;
        _model.RemoveOpenedWindow(window);
        window.Close();
    }

    public void OnCloseWidow()
    {
        var window = _model.RemoveOpenedWindow();
        if (window == null)
            return;
        window.Close();
    }
}