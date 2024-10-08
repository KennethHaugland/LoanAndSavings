using Prism.Mvvm;

namespace MoneyWithPrism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _Message = "Savings";
        public string Message
        {
            get { return _Message; }
            set { SetProperty(ref _Message, value); }
        }

        public MainWindowViewModel()
        {

        }


    }
}
