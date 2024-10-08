using MoneyWithPrism.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWithPrism.SavingsModule.ViewModels
{
    public class SavingsViewViewModel : RegionViewModelBase
    {
        private string _message;
        public SavingsViewViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _message = "View A from your Prism Module";
        }

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

    }
}
