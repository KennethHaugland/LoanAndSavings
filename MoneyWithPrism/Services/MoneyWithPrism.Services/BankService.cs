using MoneyWithPrism.Services.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MoneyWithPrism.Services
{
    public class BankService : IBankService
    {
        public double[] GetYearlySavings(double Years, double Interestrate, double MontlySavings, double YearlySavingIntervals, double StartAmount)
        {
            double r = 1 + Interestrate / 100;
            double N = Years;
            double interval = YearlySavingIntervals;

            double b = MontlySavings * (interval + Interestrate / 100 * (interval + 1) / 2);

            List<double> savings = new List<double>();

            for (double i = 0; i <= N; i++)
            {
                double result = 0;

                if (Interestrate == 0)
                    result = MontlySavings * 12 * i + StartAmount;
                else
                    result = b * (1 - Math.Pow(r, i + 1)) / (1 - r) + Math.Pow(r, i + 1) * StartAmount;

                savings.Add(result);
            }

            return savings.ToArray();
        }

        public double GetInterestrate(double Cost, double Loan, double Years)
        {
            return Math.Exp(Math.Log(Cost / Loan) / Years);
        }

        public double GetMontlyLoanPayment(double Amount, double Years, double Interestrate)
        {
            double L = Amount;

            // Total installments paid
            double N = Years * 12;
            // Interestrate in % for each month
            double r = 1 + Interestrate / 100d / 12d;
            double rN = Math.Pow(r, N);

            return Math.Ceiling(L * (1 - r) / (1 / rN - 1));
        }

        public double GetEffectiveInterestRate(double InterestRate, double Years)
        {
            // Number of installments paid in one year
            double m = 12;
            double r = InterestRate / 100;

            // Classical formula
            return (Math.Pow((1 + r / (Years * m)), Years * m) - 1) * 100;

        }

        /// <summary>
        /// Calcualates the polynomial value and its derivative
        /// </summary>
        /// <param name="x">Current x value to calculate</param>
        /// <param name="c">The polynomial coefficients</param>
        /// <returns>The polynomial value and its derivative at the value x</returns>
        private Tuple<double, double> HornersMethod(double x, params double[] c)
        {
            int n = c.Length;


            double val = c.Last();
            double dval = 0;

            for (int j = n - 2; j >= 0; j--)
            {
                dval = dval * x + val;
                val = val * x + c[j];
            }


            return new Tuple<double, double>(val, dval);

        }
    }
}
