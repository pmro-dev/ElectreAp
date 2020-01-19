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

            dictionary.Add(0, "Electre I");
            dictionary.Add(1, "Electre II");
            dictionary.Add(2, "Electre III");
            dictionary.Add(3, "Electre IV");

            comboBox1.Items.AddRange(dictionary.Values.ToArray());
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        Dictionary<int, string> dictionary = new Dictionary<int, string>();

        Form formElectre;

        private void Button_Next_Click(object sender, EventArgs e)
        {
            
            this.Hide();

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    formElectre = new Electre();
                    break;

                case 1:
                    formElectre = new Electre();
                    break;

                case 2:
                    formElectre = new Electre();
                    break;

                case 3:
                    formElectre = new Electre();
                    break;

                case 4:
                    formElectre = new Electre();
                    break;
            }

            formElectre.Show();
            
        }
    }
}
