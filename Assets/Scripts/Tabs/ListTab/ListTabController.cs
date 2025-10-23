using UnityEngine;
using Zenject;

namespace Tabs.ListTab
{
    public class ListTabController : ATabController
    {
        [Inject] private ListTabElement _listTabElement;
        [Inject(Id = Constants.LIST_SIZE)] private int _listSize;

        [SerializeField] private Transform _content;

        private bool _isCreatedList;

        public override bool IsActive { get; protected set; }

        public override void ActiveTab()
        {
            if (!_isCreatedList)
                CreateList();
            
            IsActive = true;
        }

        private void CreateList()
        {
            for (int i = 0; i < _listSize; i++)
            {
                var listTabElement = Instantiate(_listTabElement, _content);
                listTabElement.SetText(i.ToString());
            }

            _isCreatedList = true;
        }

        public override void DeactiveTab()
        {
            IsActive = false;
        }
    }
}
