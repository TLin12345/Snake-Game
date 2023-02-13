using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA5_Draft
{
    public partial class Custom : Form
    {
        public int number_Of_Apples = 1;
        public Custom()
        {
            InitializeComponent();
        }

        private void numberOfApples_ValueChanged(object sender, EventArgs e)
        {
            number_Of_Apples = (int)numberOfApples.Value;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
