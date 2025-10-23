using UnityEngine;

namespace Tabs
{
    public abstract class ATabController: MonoBehaviour
    {
        public abstract bool IsActive { get; protected set; }
        public abstract void ActiveTab();
        public abstract void DeactiveTab();
    }
}