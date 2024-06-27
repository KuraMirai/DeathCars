using UnityEngine;

namespace UI.Controllers
{
    public abstract class BaseWindowController : MonoBehaviour
    {
        public virtual async void Open()
        {
        }

        public virtual async void Close()
        {
        }
    }
}