﻿using System;
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
    public partial class History : Form
    {
        public EventHandler<string> OnSelectEvent;

        private List<Dictionary<string, string>> _history { get; set; }
        public History(List<Dictionary<string,string>> history)
        {
            InitializeComponent();

            _history = history;
            ListItems();
        }

        private void ListItems()
        {
            foreach(var formuleSolution in _history)
            {
                var dictionary = formuleSolution;
                foreach(KeyValuePair<string, string> item in dictionary)
                {
                    ListboxHistory.Items.Add(item.Value + "  =  " + item.Key);
                }
            }
        }

        private void History_DoubleClick(object sender, EventArgs e)
        {
            string solution = ListboxHistory.SelectedItem.ToString();

            int index = solution.IndexOf(' ');

            solution = solution.Substring(0, index);

            OnSelectEvent?.Invoke(this, solution);

            this.Dispose();
        }
    }
}
