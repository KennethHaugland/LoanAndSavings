using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyWithPrism.Services.Interfaces
{
    public  interface IBankService
    {
        double[] GetYearlySavings(double Years, double Interestrate, double MontlySavings, double YearlySavingIntervals, double StartAmount);

        double GetMontlyLoanPayment(double Amount, double Years, double Interestrate);

        double GetEffectiveInterestRate(double InterestRate, double Years);

        double GetInterestrate(double Cost, double Loan, double Years);
    }
}
