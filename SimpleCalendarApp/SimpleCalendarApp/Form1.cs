using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalendarApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Shows a pop-up with the date you just clicked
            MessageBox.Show("You selected: " + e.Start.ToShortDateString());

            // OR if you added a label named label1:
            // label1.Text = "Selected: " + e.Start.ToLongDateString();
        }
    }
}
