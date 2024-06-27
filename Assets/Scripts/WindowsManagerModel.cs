using System.Collections.Generic;
using System.Linq;
using UI.Controllers;

public class WindowsManagerModel
{
        private readonly List<BaseWindowController> _openedWindows = new ();

        public void AddOpenedWindow<T>(T controller) where T : BaseWindowController
        {
                var window = _openedWindows.FirstOrDefault(w => w  is T);
                if (window != null)
                        return;
                _openedWindows.Add(controller);
        }

        public void RemoveOpenedWindow<T>(T controller) where T : BaseWindowController
        {
                var window = _openedWindows.FirstOrDefault(w => w is T);
                if (window == null)
                        return;
                _openedWindows.Remove(controller);
        }

        public BaseWindowController RemoveOpenedWindow()
        {
                var window = _openedWindows.LastOrDefault();
                if (window == null)
                        return null;
                _openedWindows.Remove(window);
                return window;
        }
}