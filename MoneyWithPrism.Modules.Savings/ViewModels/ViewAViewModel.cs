using OxyPlot;
using Prism.Commands;
using Prism.Mvvm;
using MoneyWithPrism.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyWithPrism.Services.Interfaces;

namespace MoneyWithPrism.Modules.Savings.ViewModels
{
    public class ViewAViewModel : BindableBase
    {

        public IBankService BankService { get; set; }

        private double pStartAmount = 200000;
        public double StartAmount
        {
            get { return pStartAmount; }
            set { SetProperty(ref pStartAmount, value); }
        }


        private double pMontlySavings = 500;
        public double MonthlySavings
        {
            get { return pMontlySavings; }
            set { SetProperty(ref pMontlySavings, value); }
        }

        private double pYearsOfSaving = 70;
        public double YearsOfSaving
        {
            get { return pYearsOfSaving; }
            set { SetProperty(ref pYearsOfSaving, value); }
        }

        private double pInterestRate = 10d;
        public double InterestRate
        {
            get { return pInterestRate; }
            set { SetProperty(ref pInterestRate, value); }
        }

        private double pSavingIntervals = 12d;
        public double SavingInterval
        {
            get { return pSavingIntervals; }
            set { SetProperty(ref pSavingIntervals, value); }
        }

        private double pTotalSavings;
        public double TotalSavings
        {
            get { return pTotalSavings; }
            set { SetProperty(ref pTotalSavings, value); }
        }

        private string _message = "Savings";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private PlotModel pSelectedPlotModel = new PlotModel();
        public PlotModel SelectedPlotModel
        {
            get { return pSelectedPlotModel; }
            set { SetProperty(ref pSelectedPlotModel, value); }
        }

        private DelegateCommand _SavingCommand;
        public DelegateCommand SavingCommand =>
            _SavingCommand ?? (_SavingCommand = new DelegateCommand(ExecuteSavingCommand));

        void ExecuteSavingCommand()
        {
            PlotModel p = new PlotModel();
            
            double[] Money = BankService.GetYearlySavings(YearsOfSaving, InterestRate, MonthlySavings, SavingInterval, StartAmount);
            double[] MoneyLow = BankService.GetYearlySavings(YearsOfSaving, InterestRate -1 , MonthlySavings, SavingInterval, StartAmount);
            double[] MoneyLHigh = BankService.GetYearlySavings(YearsOfSaving, InterestRate + 1, MonthlySavings, SavingInterval, StartAmount);
            p = OxyPlotHelpers.Plot(new List<double[]>(){ Money, MoneyLow, MoneyLHigh });
            OxyPlotHelpers.SetYAxis(p);

            SelectedPlotModel = p;

            TotalSavings = Math.Round(Money.Last(),0);

        }


        public ViewAViewModel(IBankService bankService)
        {
            BankService = bankService;
            Message = "Savings Module";
            ExecuteSavingCommand();
        }
    }
}
