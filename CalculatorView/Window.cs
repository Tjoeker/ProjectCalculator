using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorView
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private static int _aantalHaakjes = 0;

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
                char sign = text[checkPosition];

                if (sign == '+' || sign == '-' || sign == '*' || sign == '/')
                {
                    return true;
                }
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
                TextboxInput.Text += ".";
            }
            else
                MessageBox.Show("Een getal kan geen 2 komma's bevatten");
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
        }
    }
}
