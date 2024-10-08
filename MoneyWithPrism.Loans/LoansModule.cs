using MoneyWithPrism.Core;
using MoneyWithPrism.Loans.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MoneyWithPrism.Loans
{
    public class LoansModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public LoansModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.LoansRegion, "ViewA");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}