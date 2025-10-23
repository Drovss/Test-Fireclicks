using Tabs.ListTab;
using UnityEngine;
using Zenject;

namespace Instellers
{
    public class TabInstaller : MonoInstaller
    {
        [SerializeField] private ListTabElement _listTabElement;
        [SerializeField] private int _listSize;
        public override void InstallBindings()
        {
            Container
                .Bind<ListTabElement>()
                .FromInstance(_listTabElement)
                .AsTransient();

            Container
                .Bind<int>()
                .WithId(Constants.LIST_SIZE)
                .FromInstance(_listSize)
                .AsSingle();
        }
        
    }
}