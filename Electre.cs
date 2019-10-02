using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectreAp
{
    public partial class UserControl: System.Windows.Forms.UserControl
    {
        public UserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Load(object sender, EventArgs e)
        {

        }

        public int numbersOfCriterias;
        public int numbersOfAlternatives;

        private void Button_CreateTab_Click(object sender, EventArgs e)
        {
            try
            {
                //Reset(0);
                numbersOfCriterias = Int32.Parse(textBox_Criteria.Text);
                numbersOfAlternatives = Int32.Parse(textBox_Alternatives.Text);

  //              TworzenieTabeli(liczbaAlternatyw, liczbaKryteriow);

//                listaWartProgKryt = new Double[liczbaKryteriow][3][2];

                // wypełnianie zerami
/*                for (int i = 0; i < listaWartProgKryt.length; i++)
                {
                    for (int j = 0; j < listaWartProgKryt[0].length; j++)
                    {
                        for (int k = 0; k < listaWartProgKryt[0][0].length; k++)
                        {
                            listaWartProgKryt[i][j][k] = 0.0;
                        }
                    }
                }
*/

            }
            catch (Exception)
            {
                //PokazAlert("Informacja", "Błąd", "Do pól można wprowadzać tylko liczby całkowite!");
                throw;
            }

        }

        private void Button_ReadTab_Click(object sender, EventArgs e)
        {

        }

        private void Button_SaveTab_Click(object sender, EventArgs e)
        {

        }

        private void Button_Calculate_Click(object sender, EventArgs e)
        {

        }

        private void Button_SaveData_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_TurnOffVeto_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_CheckAllOptions_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_ComplianceSet_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_CompatibilityMatrix_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_NonComplianceSets_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_OutrankingSets_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_SetEqualityMatrix_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_CredibilityMatrix_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_RatingMatrix_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_TopDownDistillation_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_UpwardDistillation_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_Rankings_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_Alternatives_FokusLeave(object sender, EventArgs e)
        {

        }

        private void TextBox_Criteria_FokusLeave(object sender, EventArgs e)
        {

        }

        private void TextBox_Alfa1_FokusLeave(object sender, EventArgs e)
        {

        }

        private void TextBox_Beta1_FokusLeave(object sender, EventArgs e)
        {

        }

        private void TextBox_Beta2_FokusLeave(object sender, EventArgs e)
        {

        }

        private void TextBox_Beta3_FokusLeave(object sender, EventArgs e)
        {

        }

        private void TextBox_Beta4_FokusLeave(object sender, EventArgs e)
        {

        }

        private void TextBox_Alfa2_FokusLeave(object sender, EventArgs e)
        {

        }

        private void TextBox_Alfa3_FokusLeave(object sender, EventArgs e)
        {

        }

        private void TextBox_Alfa4_FokusLeave(object sender, EventArgs e)
        {

        }

        private void ListView_CriteriaToChose_ItemActivate(object sender, EventArgs e)
        {

        }

        private void TextBox_DecimalPlaces_FokusLeave(object sender, EventArgs e)
        {

        }
    }
}
