using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tabs.ListTab
{
    public class ListTabController : ATabController
    {
        [Inject] private ListTabElement _listTabElement;
        [Inject(Id = Constants.LIST_SIZE)] private int _listSize;

        [SerializeField] private Transform _rootTransform;
        [SerializeField] private Transform _content;

        private bool _isInit;
        private readonly List<ListTabElement> _listTabElements = new();

        public override bool IsActive { get; protected set; }

        public override void ActiveTab()
        {
            IsActive = true;
            Init();
            _rootTransform.gameObject.SetActive(true);
        }

        private void Init()
        {
            if (_isInit)
                return;

            for (int i = 0; i < _listSize; i++)
            {
                var listTabElement = Instantiate(_listTabElement, _content);
                listTabElement.SetText(i.ToString());
                _listTabElements.Add(listTabElement);
            }

            _isInit = true;
        }

        public override void DeactiveTab()
        {
            _rootTransform.gameObject.SetActive(false);
            IsActive = false;
        }

        private void OnDestroy()
        {
            foreach (var element in _listTabElements)
            {
                Destroy(element.gameObject);
            }

            _listTabElements.Clear();
        }
    }
}
