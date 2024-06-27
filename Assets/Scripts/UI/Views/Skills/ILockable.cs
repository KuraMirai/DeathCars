using System;

namespace UI.Views.Skills
{
    public interface ILockable
    {
        public bool Locked { get; }
        public event Action LockStateChanged;
        public void InitLockUnlockView();
        public void LockUnlock(bool state);
        public void SetLockUnlockView();
    }
}