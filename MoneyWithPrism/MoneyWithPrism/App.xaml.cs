using MoneyWithPrism.Loans;
using MoneyWithPrism.Modules.ModuleName;
using MoneyWithPrism.Modules.Savings;
using MoneyWithPrism.Services;
using MoneyWithPrism.Services.Interfaces;
using MoneyWithPrism.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace MoneyWithPrism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            containerRegistry.RegisterSingleton<IBankService, BankService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
            moduleCatalog.AddModule<SavingsModule>();
            moduleCatalog.AddModule<LoansModule>();
        }
    }
}
