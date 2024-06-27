using UnityEngine;

namespace UI.Controllers
{
    public abstract class MultipleAnimationsWindowController : BaseWindowController
    {
        [SerializeField] protected BaseAnimationComponent[] childrenAnimationComponents;
    }
}