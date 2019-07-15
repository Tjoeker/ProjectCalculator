using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;

namespace CalculatorView
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void Calculate()
        {
            TextboxFormule.Text += TextboxInput.Text;

            Calculator.Calculator calc = new Calculator.Calculator();

            string solution = calc.Calculate(TextboxFormule.Text);

            TextboxFormule.Clear();
            TextboxInput.Text = solution;
        }

        private int _aantalHaakjes = 0;

        private void LoseFocus()
        {
            TextboxInput.Focus();
            TextboxInput.SelectionStart = TextboxInput.Text.Length;
            TextboxInput.SelectionLength = 0;
        }

        private bool CheckIfSign(string text, int checkPosition)
        {
            if(text != "")
            {
                char sign = text[text.Length - 1];

                if (sign == '+' || sign == '-' || sign == '*' || sign == '/')
                {
                    return true;
                }
                return false;
            }
            else if (TextboxFormule.Text.Length > 0 && TextboxFormule.Text[TextboxFormule.Text.Length - 1] == ')')
            {
                return false;
            }

            return true;
        }
        private void Numeric_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            TextboxInput.Text += button.Text;
            LoseFocus();
        }

        private void ButtonDecimal_Click(object sender, EventArgs e)
        {
            if (!TextboxInput.Text.Contains('.'))
            {
                TextboxInput.Text += System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            }
            else
                MessageBox.Show("Een getal kan geen 2 komma's bevatten");
            LoseFocus();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if(!CheckIfSign(TextboxInput.Text, TextboxInput.Text.Length - 1))
            {
                TextboxFormule.Text += TextboxInput.Text;
                TextboxInput.Clear();
                TextboxInput.Text += "+";
                LoseFocus();
            }
            else
            {
                MessageBox.Show("Hier kan geen + staan");
            }
        }

        private void ButtonSubtract_Click(object sender, EventArgs e)
        {
            if(TextboxInput.Text.Length == 0 || (TextboxInput.Text.Length == 1 && CheckIfSign(TextboxInput.Text, 0) && !CheckIfSign(TextboxFormule.Text, TextboxFormule.Text.Length - 1)))
            {
                TextboxInput.Text += "-";
            }
            else if(TextboxInput.Text.Length < 2 || !CheckIfSign(TextboxInput.Text, 1))
            {
                TextboxFormule.Text += TextboxInput.Text;
                TextboxInput.Clear();
                TextboxInput.Text += "-";
            }
            else
            {
                MessageBox.Show("Hier kan geen - staan");
            }
            LoseFocus();
        }

        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            if (!CheckIfSign(TextboxInput.Text, TextboxInput.Text.Length - 1))
            {
                TextboxFormule.Text += TextboxInput.Text;
                TextboxInput.Clear();
                TextboxInput.Text += "*";
                LoseFocus();
            }
            else
            {
                MessageBox.Show("Hier kan geen x staan");
            }
        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            if (!CheckIfSign(TextboxInput.Text, TextboxInput.Text.Length - 1))
            {
                TextboxFormule.Text += TextboxInput.Text;
                TextboxInput.Clear();
                TextboxInput.Text += "/";
                LoseFocus();
            }
            else
            {
                MessageBox.Show("Hier kan geen / staan");
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            TextboxInput.Clear();
            TextboxFormule.Clear();
            LoseFocus();
        }

        private void ButtonBackspace_Click(object sender, EventArgs e)
        {
            if(TextboxInput.Text.Length > 0)
            TextboxInput.Text = TextboxInput.Text.Remove(TextboxInput.Text.Length - 1);
            LoseFocus();
        }

        private void ButtonLeftBracket_Click(object sender, EventArgs e)
        {
            if(CheckIfSign(TextboxInput.Text,0))
            {
                TextboxFormule.Text += TextboxInput.Text;
                TextboxInput.Clear();
                TextboxFormule.Text += "(";
                _aantalHaakjes++;
            }
            else
            {
                MessageBox.Show("Je kan geen haakjes plaatsen op deze plaats");
            }
            LoseFocus();
        }

        private void ButtonRightBracket_Click(object sender, EventArgs e)
        {
            bool sign = CheckIfSign(TextboxInput.Text,0);

            if (_aantalHaakjes > 0 &&  !sign)
            {
                TextboxFormule.Text += TextboxInput.Text;
                TextboxInput.Clear();
                TextboxFormule.Text += ")";
                _aantalHaakjes--;
            }
            else if (sign)
            {
                MessageBox.Show("Je kan geen haakjes plaatsen op deze plaats");
            }
            else
            {
                MessageBox.Show("Er zijn geen haakjes om te sluiten");
            }
            LoseFocus();
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;

            switch (key)
            {
                case '0':
                    Numeric_Button_Click(Button0, e);
                    break;
                case '1':
                    Numeric_Button_Click(Button1, e);
                    break;
                case '2':
                    Numeric_Button_Click(Button2, e);
                    break;
                case '3':
                    Numeric_Button_Click(Button3, e);
                    break;
                case '4':
                    Numeric_Button_Click(Button4, e);
                    break;
                case '5':
                    Numeric_Button_Click(Button5, e);
                    break;
                case '6':
                    Numeric_Button_Click(Button6, e);
                    break;
                case '7':
                    Numeric_Button_Click(Button7, e);
                    break;
                case '8':
                    Numeric_Button_Click(Button8, e);
                    break;
                case '9':
                    Numeric_Button_Click(Button9, e);
                    break;
                case '.':
                    ButtonDecimal_Click(ButtonDecimal, e);
                    break;
                case ',':
                    ButtonDecimal_Click(ButtonDecimal, e);
                    break;
                case '(':
                    ButtonLeftBracket_Click(ButtonLeftBracket, e);
                    break;
                case ')':
                    ButtonRightBracket_Click(ButtonRightBracket, e);
                    break;
                case '+':
                    ButtonAdd_Click(ButtonAdd, e);
                    break;
                case '-':
                    ButtonSubtract_Click(ButtonSubtract, e);
                    break;
                case '*':
                    ButtonMultiply_Click(ButtonMultiply, e);
                    break;
                case '/':
                    ButtonDivide_Click(ButtonDivide, e);
                    break;
                case (char)8:
                    ButtonBackspace_Click(ButtonBackspace, e);
                    break;
                case (char)13:
                    Calculate();
                    break;
                default:
                    break;
            }
        }

        private void Calculate(object sender, EventArgs e)
        {
            Calculate();
            LoseFocus();
        }
    }
}
