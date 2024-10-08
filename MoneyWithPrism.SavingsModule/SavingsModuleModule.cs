using MoneyWithPrism.Core;
using MoneyWithPrism.SavingsModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MoneyWithPrism.SavingsModule
{
    public class SavingsModuleModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public SavingsModuleModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "SavingsView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SavingsView>();
        }
    }
}