using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWithPrism.Core
{
    public static class OxyPlotHelpers
    {

        public static PlotModel Plot(List<double[]> _input, params double[] _x)
        {
            PlotModel p = new PlotModel();

            double[] x;

            if (_x.Length == 0)
            {
                x = new double[_input[0].Length];
                for (int i = 0; i < _input[0].Length; i++)
                {
                    x[i] = (double)i;
                }
            }
            else if (_x.Length == _input[0].Length)
            {
                x = new double[_input[0].Length];
                for (int i = 0; i < _input[0].Length; i++)
                {
                    x[i] = _x[i];
                }
            }
            else
            {
                // ignores the _x vector input
                x = new double[_input[0].Length];
                for (int i = 0; i < _input[0].Length; i++)
                {
                    x[i] = (double)i;
                }
            }

     
            foreach (var input in _input)
            {
                var CurrentSerie = new LineSeries { MarkerType = MarkerType.None };

                for (int i = 0; i < _input[0].Length; i++)
            {
                CurrentSerie.Points.Add(new DataPoint(x[i], input[i]));
            }

            p.Series.Add(CurrentSerie);
            }
            return p;
        }


        public static PlotModel Plot(PlotModel p, double[] _input, params double[] _x)
        { 
            

            double[] x;

            if (_x.Length == 0)
            {
                x = new double[_input.Length];
                for (int i = 0; i < _input.Length; i++)
                {
                    x[i] = (double)i;
                }
            }
            else if (_x.Length == _input.Length)
            {
                x = new double[_input.Length];
                for (int i = 0; i < _input.Length; i++)
                {
                    x[i] = _x[i];
                }
            }
            else
            {
                // ignores the _x vector input
                x = new double[_input.Length];
                for (int i = 0; i < _input.Length; i++)
                {
                    x[i] = (double)i;
                }
            }

            var CurrentSerie = new LineSeries { MarkerType = MarkerType.None };
            for (int i = 0; i < _input.Length; i++)
            {
                CurrentSerie.Points.Add(new DataPoint(x[i], _input[i]));
            }

            p.Series.Add(CurrentSerie);

            return p;        
        }

        public static void SetYAxis(PlotModel plotModel, double min = 0, double max = 1.2d, string title = "Absorbtion factor")
        {

            var linearAxis = new LinearAxis
            {
                //Maximum = max,
                //Minimum = min,
                Title = title,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                 LabelFormatter = _formatter,
            };

            plotModel.Axes.Add(linearAxis);
        }

        private static string _formatter(double d)
        {
            if (d < 1E3)
            {
                return String.Format("{0}", d);
            }
            else if (d >= 1E3 && d < 1E6)
            {
                return String.Format("{0}K", d / 1E3);
            }
            else if (d >= 1E6 && d < 1E9)
            {
                return String.Format("{0}M", d / 1E6);
            }
            else if (d >= 1E9)
            {
                return String.Format("{0}B", d / 1E9);
            }
            else
            {
                return String.Format("{0}", d);
            }
        }

        public static void SetXAxis(PlotModel plotModel, double min = 50d, double max = 5000d, string title = "Freqency [Hz]")      
        {
            LogarithmicAxis logarithmicAxis = new LogarithmicAxis
            {
                Maximum = 50,
                Minimum = 5000,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Bottom,
                Title = title
            };

            plotModel.Axes.Add(logarithmicAxis);
        }
    }
}
