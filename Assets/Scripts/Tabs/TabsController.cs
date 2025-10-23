using System.Collections.Generic;
using UnityEngine;

namespace Tabs
{
    public class TabsController : MonoBehaviour
    {
        [SerializeField] private List<Tab>  tabs = new();

        private void Start()
        {
            Init();
            DeactiveTabs();
            ActiveDefault();
        }

        private void ActiveDefault()
        {
            if(tabs.Count > 0)
                tabs[0].TabController.ActiveTab();
        }

        private void Init()
        {
            foreach (var tab in tabs)
            {
                tab.TabController.DeactiveTab();
                tab.Button.onClick.AddListener(DeactiveTabs);
                tab.Button.onClick.AddListener(tab.TabController.ActiveTab);
            }
        }

        private void DeactiveTabs()
        {
            foreach (var tab in tabs)
            {
                if(tab.TabController.IsActive)
                    tab.TabController.DeactiveTab();
            }
        }

        private void OnDestroy()
        {
            foreach (var tab in tabs)
            {
                tab.Button.onClick.RemoveAllListeners();
            }
        }
    }
}