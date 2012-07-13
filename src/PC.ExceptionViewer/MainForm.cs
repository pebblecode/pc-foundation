using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PebbleCode.ExceptionViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = FormatText(textBox1.Text);
        }

        private string FormatText(string text)
        {
            return text.Replace("///", Environment.NewLine);
        }
    }
}
