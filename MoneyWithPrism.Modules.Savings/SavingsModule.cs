using MoneyWithPrism.Core;
using MoneyWithPrism.Modules.Savings.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MoneyWithPrism.Modules.Savings
{
    public class SavingsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public SavingsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.SavingsRegion, "ViewA");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}