using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace CheckValue
{
    /// <summary>
    /// This library can check if user value is correct and show problem.
    /// </summary>
    class CheckValue
    {
        /// <param name="tBlockMessage">Place to write error</param>
        /// <param name="tBoxValue">Take value form there. 
        /// If it's wrong, it change background on LightPink color.</param>
        /// /// <param name="_min">Minimum correct value</param>
        /// /// <param name="tBlockMessage">Maximum correct value</param>
        public CheckValue(TextBlock tBlockMessage, TextBox tBoxValue, double _max, double _min = 0)
        {
            textBoxValue = tBoxValue;
            textBlockMessage = tBlockMessage;
            max = _max;
            min = _min;
        }

        private TextBox textBoxValue;
        private TextBlock textBlockMessage;
        private double max;
        private double min;
        public bool Error { get; private set; }

        private static string changeDotOnComma(string s_number)
        {
            return s_number.Replace('.', ',');
        }
        /// <summary>
        /// If value isn't correct print error and set Error on true.
        /// </summary>
        public double Cheack()
        {
            double value = 0;
            try
            {
                value = double.Parse(changeDotOnComma(textBoxValue.Text));
                if (value > max) throw new Exception("ZaDuzy");
                if (value < min) throw new Exception("ZaMaly");
                textBlockMessage.Text = "";
                textBoxValue.Background = Brushes.White;
                Error = false;
            }
            catch (FormatException)
            {
                textBlockMessage.Text = "Nie podano poprawnie liczby";
                textBoxValue.Background = Brushes.LightPink;
                Error = true;
            }
            catch (Exception error_code)
            {
                if (error_code.Message == "ZaDuzy")
                {
                    textBlockMessage.Text = $"Podano zbyt dużą liczbę. Maksymalna wartość to {max}";
                }
                if (error_code.Message == "ZaMaly")
                {
                    textBlockMessage.Text = $"Podano zbyt małą liczbę. Minimalna wartość to {min}";
                }
                textBoxValue.Background = System.Windows.Media.Brushes.LightPink;
                Error = true;
            }
            return value;
        }
        /// <summary>
        /// Delete error message, value from textBox and set white color of textBox background
        /// </summary>
        public void Clear()
        {
            textBoxValue.Text = "";
            textBlockMessage.Text = "";
            textBoxValue.Background = Brushes.White;
        }

        /// <summary>
        /// Delete error message and set white color of textBox background
        /// </summary>
        public void ClearError()
        {
            textBlockMessage.Text = "";
            textBoxValue.Background = Brushes.White;
        }

    }
}