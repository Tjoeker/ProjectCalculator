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

        private void LoseFocus()
        {
            TextboxInput.Focus();
            TextboxInput.SelectionStart = TextboxInput.Text.Length;
            TextboxInput.SelectionLength = 0;
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            TextboxInput.Text += 0;
            LoseFocus();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TextboxInput.Text += 1;
            LoseFocus();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TextboxInput.Text += 2;
            LoseFocus();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            TextboxInput.Text += 3;
            LoseFocus();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            TextboxInput.Text += 4;
            LoseFocus();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            TextboxInput.Text += 5;
            LoseFocus();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            TextboxInput.Text += 6;
            LoseFocus();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            TextboxInput.Text += 7;
            LoseFocus();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            TextboxInput.Text += 8;
            LoseFocus();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            TextboxInput.Text += 9;
            LoseFocus();
        }

        private void ButtonDecimal_Click(object sender, EventArgs e)
        {
            TextboxInput.Text += ".";
            LoseFocus();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            TextboxFormule.Text += TextboxInput.Text;
            TextboxInput.Clear();
            TextboxInput.Text += "+";
            LoseFocus();
        }

        private void ButtonSubtract_Click(object sender, EventArgs e)
        {
            if(TextboxInput.Text.Length == 1 && (TextboxInput.Text[0] == '+' || TextboxInput.Text[0] == '-' || TextboxInput.Text[0] == '*' || TextboxInput.Text[0] == '/'))
            {
                TextboxInput.Text += "-";
            }
            else
            {
                TextboxFormule.Text += TextboxInput.Text;
                TextboxInput.Clear();
                TextboxInput.Text += "-";
            }
            LoseFocus();
        }

        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            TextboxFormule.Text += TextboxInput.Text;
            TextboxInput.Clear();
            TextboxInput.Text += "*";
            LoseFocus();
        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            TextboxFormule.Text += TextboxInput.Text;
            TextboxInput.Clear();
            TextboxInput.Text += "/";
            LoseFocus();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            TextboxInput.Clear();
            TextboxFormule.Clear();
            LoseFocus();
        }
    }
}
