﻿using MoneyWithPrism.Core.Mvvm;
using MoneyWithPrism.Services.Interfaces;
using Prism.Regions;

namespace MoneyWithPrism.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message = "Prism sucks";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }



        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
           // Message = messageService.GetMessage();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
