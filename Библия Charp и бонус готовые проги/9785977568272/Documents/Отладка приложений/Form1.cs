using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 10;
            int y = 15;
            x = Double(x);
            x = x / (y - 15);
            MessageBox.Show(x.ToString());
        }

        int Double(int x)
        {
            return x * 2;
        }
    }
}
