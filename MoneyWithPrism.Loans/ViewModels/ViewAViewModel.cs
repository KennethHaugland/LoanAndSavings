using MoneyWithPrism.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWithPrism.Loans.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        #region "Properties"
        private string _message = "Loans";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private IBankService pBankService;
        public IBankService BankService
        {
            get { return pBankService; }
            set { SetProperty(ref pBankService, value); }
        }

        private double pYears = 30d;
        public double Years
        {
            get { return pYears; }
            set { SetProperty(ref pYears, value); }
        }

        private double pLoanAmount = 4500000d;
        public double LoanAmount
        {
            get { return pLoanAmount; }
            set { SetProperty(ref pLoanAmount, value); }
        }

        private double pInterestRate = 5.49d;
        public double InterestRate
        {
            get { return pInterestRate; }
            set { SetProperty(ref pInterestRate, value); }
        }


        private double pMontlyPayment;
        public double MontlyPayments
        {
            get { return pMontlyPayment; }
            set { SetProperty(ref pMontlyPayment, value); }
        }

        private double pMontlyFee = 65d;
        public double MontlyFee
        {
            get { return pMontlyFee; }
            set { SetProperty(ref pMontlyFee, value); }
        }

        private double pTotalCost;
        public double TotalCost
        {
            get { return pTotalCost; }
            set { SetProperty(ref pTotalCost, value); }
        }

        private double pEffectiveInterestRate;
        public double EffectiveInterestRate
        {
            get { return pEffectiveInterestRate; }
            set { SetProperty(ref pEffectiveInterestRate, value); }
        }

        #endregion

        #region "Commands"
        private DelegateCommand _LoanCommand;
        public DelegateCommand LoanCommand =>
            _LoanCommand ?? (_LoanCommand = new DelegateCommand(ExecuteLoandCommand));

        void ExecuteLoandCommand()
        {
            MontlyPayments = MontlyFee + BankService.GetMontlyLoanPayment(LoanAmount, Years, InterestRate);

            TotalCost = MontlyPayments * 12 * Years;
            EffectiveInterestRate = BankService.GetEffectiveInterestRate(InterestRate, Years);
            double dd = 100*(BankService.GetInterestrate(TotalCost, LoanAmount, Years) - 1d);
            double ff = EffectiveInterestRate / dd;
         }

        #endregion

        #region "Ctor"
        public ViewAViewModel(IBankService bankService)
        {
            BankService = bankService;
            ExecuteLoandCommand();
        }
        #endregion
    }
}
