using System.Collections.Generic;
using UnityEngine;

namespace Tabs
{
    public class TabsController : MonoBehaviour
    {
        [SerializeField] List<Tab>  tabs = new List<Tab>();

        private void Start()
        {
            Init();
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
                tab.Button.onClick.AddListener(tab.TabController.ActiveTab);
            }
        }
    }
}