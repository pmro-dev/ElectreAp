using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectreAp
{
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();
        }

        private void Button_Next_Click(object sender, EventArgs e)
        {
            
            this.Hide();

            Electre formElectre = new Electre();

            formElectre.Show();

        }
    }
}
