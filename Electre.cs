using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ElectreAp
{
    public partial class Electre : Form
    {
        public Electre()
        {
            InitializeComponent();
        }

        private void UserControl_Load(object sender, EventArgs e)
        {

        }


        ElectreIII taskElectreIII = new ElectreIII();
        int alternatives = 0;
        int criteria = 0;

        private void Button_CreateTab_Click(object sender, EventArgs e) {

            alternatives = Int32.Parse(textBox_Alternatives.Text);
            criteria = Int32.Parse(textBox_Criteria.Text);
            
            dataGridView_Matrix.DataSource = taskElectreIII.CreateTable(alternatives, criteria);
            dataGridView_Matrix.Columns[0].ReadOnly = true;
            dataGridView_Matrix.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(202,202,202);
            dataGridView_Matrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView_Matrix.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            
            listBox_CriteriaToChose.Items.AddRange(taskElectreIII.ColumnNamesDoListy.ToArray());
            listBox_CriteriaToChose.Font = new Font(listBox_CriteriaToChose.Font.Name, 10);
            listBox_CriteriaToChose.HorizontalScrollbar = true;
        }

        private void Button_ReadTab_Click(object sender, EventArgs e) {

        }

        private void Button_SaveTab_Click(object sender, EventArgs e) {

        }


        string pathMathImg = "";
        List<Int32> lul = new List<Int32>();
        private void Button_Calculate_Click(object sender, EventArgs e) {
            tabControl_LeaderBoards.TabPages.Clear();
            //Reset(2);

            try {
                if (textBox_Alfa.Text != taskElectreIII.Beta.ToString()) {
                    taskElectreIII.Alfa = Double.Parse(textBox_Alfa.Text);
                }

                if (textBox_Beta.Text != taskElectreIII.Alfa.ToString()) {
                    taskElectreIII.Beta = Double.Parse(textBox_Beta.Text);
                }

                if (textBox_DecimalPlaces.Text != taskElectreIII.MiejscPoPrzecinku.ToString()) {
                    taskElectreIII.MiejscPoPrzecinku = Int32.Parse(textBox_DecimalPlaces.Text);
                }

            }
            catch (Exception ex) {
                MessageBox.Show("W polach Alfa, Beta i Miejsca po przecniku można wprowadzać tylko cyfry! \n Ponadto dla Alfa i Beta używamy kropki nie przecinka", "Błąd", MessageBoxButtons.OK);
                Console.WriteLine(ex);
            }

            //taskElectreIII.DoCalculations();
            taskElectreIII.DivideThresholdsToLists();
            taskElectreIII.CreateMatrixForAlternativeData(taskElectreIII.NumberOfAlternatives, taskElectreIII.NumberOfCriterias);
            taskElectreIII.CreateConcordanceSets();

            string ps = AppDomain.CurrentDomain.BaseDirectory;
            pathMathImg = ps + "\\MathImg\\wzor_mal_direct_prog.PNG";
            PrepareImgToShow(pathMathImg);
            pathMathImg = ps + "\\MathImg\\wzor_rosn_direct_prog.PNG";
            PrepareImgToShow(pathMathImg);
            pathMathImg = ps + "\\MathImg\\wzor_mal_invers_prog.PNG";
            PrepareImgToShow(pathMathImg);
            pathMathImg = ps + "\\MathImg\\wzor_rosn_invers_prog.PNG";
            PrepareImgToShow(pathMathImg);
            pathMathImg = ps + "\\MathImg\\wzor_przeliczanie_wspolczynnikow.PNG";
            PrepareImgToShow(pathMathImg);

            if(taskElectreIII.CboxConcordanceSetsChecked) {
                taskElectreIII.ShowConcordanceSets();
                pathMathImg = ps + "\\MathImg\\wspolczynnik_zgodnosci_kryterium_rosn.PNG";
                PrepareImgToShow(pathMathImg);
                pathMathImg = ps + "\\MathImg\\wspolczynnik_zgodnosci_kryterium_mal.PNG";
                PrepareImgToShow(pathMathImg);
            }

            taskElectreIII.CreateConcordanceMatrix();

            if (taskElectreIII.CboxConcordanceMatrixChecked) {
                taskElectreIII.ShowConcordanceMatrix();
                pathMathImg = ps + "\\MathImg\\indeks_zgodnosci.PNG";
                PrepareImgToShow(pathMathImg);
            }

            taskElectreIII.CreateDiscordanceSets();

            if (taskElectreIII.CboxNonConcordanceSetsChecked) {
                taskElectreIII.ShowDiscordanceSets();
                pathMathImg = ps + "\\MathImg\\wspolczynnik_niezgodnosci_kryterium_rosn.PNG";
                PrepareImgToShow(pathMathImg);
                pathMathImg = ps + "\\MathImg\\wspolczynnik_niezgodnosci_kryterium_mal.PNG";
                PrepareImgToShow(pathMathImg);
            }

            taskElectreIII.CreateOutrankingSets();

            if (taskElectreIII.CboxOutrankingSetsChecked) {
                taskElectreIII.ShowOutrankingSets();
                pathMathImg = ps + "\\MathImg\\WartoscPrzewyzszania.JPG";
                PrepareImgToShow(pathMathImg);
            }

            // tworz zbiory wiarygodnosci
            taskElectreIII.DoStageFirst();

            if (taskElectreIII.CboxSetEqualityMatrixChecked) {
                taskElectreIII.ShowStageFirst();
                //WypiszEtap1(matrixRownosciZbiorowPrzewyzszania);
            }

            taskElectreIII.DoStageSecond();

            if (taskElectreIII.CboxCredibilityMatrixChecked) {
                taskElectreIII.ShowStageSecond();
                //WypiszEtap2(credibilityMatrix);
                pathMathImg = ps + "\\MathImg\\indeks_wiarygodnosci.PNG";
                PrepareImgToShow(pathMathImg);
            }

            taskElectreIII.PrepareTopDownDistillation();
            // wykonaj destylacje zstępującą
            taskElectreIII.DoStepSecond(taskElectreIII.RoboczyMatrixDOgol, taskElectreIII.TypDestylacji, taskElectreIII.ListaNumerowZNazwOpcjiOgolZstep);
            //Krok2(roboczyMatrixDOgol, typDestylacji, listaNumerowZNazwOpcjiOgolZstep);
            
            taskElectreIII.PrepareUpwardDistillation();

            // wykonaj destylację wstępującą
            taskElectreIII.DoStepSecond(taskElectreIII.RoboczyMatrixDOgol, taskElectreIII.TypDestylacji, taskElectreIII.ListaNumerowZNazwOpcjiOgolWstep);
            //Krok2(roboczyMatrixDOgol, typDestylacji, listaNumerowZNazwOpcjiOgolWstep);

            if (taskElectreIII.CboxTopDownDistillationChecked) {
                taskElectreIII.ShowTopDownDiistillation();
                //WypisywanieZstep();
            }

            taskElectreIII.PrepareUpwardScore();

            if (taskElectreIII.CboxUpwardDistillationChecked) {
                taskElectreIII.ShowUpwardDistillation();
                //WypisywanieWstep();
            }

            if (taskElectreIII.CboxUpwardDistillationChecked || taskElectreIII.CboxTopDownDistillationChecked) {
                pathMathImg = ps + "\\MathImg\\alfa_zero.PNG";
                PrepareImgToShow(pathMathImg);
                pathMathImg = ps + "\\MathImg\\s_alfa.PNG";
                PrepareImgToShow(pathMathImg);
                pathMathImg = ps + "\\MathImg\\alfa_nplus.PNG";
                PrepareImgToShow(pathMathImg);
            }

            taskElectreIII.CreateTabTopDown();
            //UtworzTabZstep();
            taskElectreIII.ShowTabOfDistillation(taskElectreIII.TabZstep);
            //WypiszTabDest(TabZstep);

            taskElectreIII.CreateTabUpward();
            //UtworzTabWstep();
            taskElectreIII.ShowTabOfDistillation(taskElectreIII.TabWstep);
            //WypiszTabDest(TabWstep);

            taskElectreIII.CreateSumTableOfDistillations();
            //UtworzTabSum();
            taskElectreIII.ShowTabOfDistillation(taskElectreIII.TabSum);
            //WypiszTabDest(TabSum);
            
            if (taskElectreIII.CboxRankingsChecked) {
                AddTabPage(taskElectreIII.MiejscaOpcjiPoDestylacjiZstepujacej, "Rank. Zstep.");
                AddTabPage(taskElectreIII.MiejscaOpcjiPoDestylacjiWstepujacej, "Rank. Wstep.");
                AddTabPage(taskElectreIII.TabSum, "Finalna Macierz Zależności", lul);
            }

            taskElectreIII.CreateFinalRanking();
            //RankingFinalowy(TabSum);
                        
            if (checkBox_Rankings.Checked) {
                AddTabPage(taskElectreIII.TabRank, "Rank. Final.");
            }
        }

        public void PrepareImgToShow(String pathMathImg) {
            try {
                PictureBox pictureBox = new PictureBox();
                Image img = Image.FromFile(pathMathImg);
                pictureBox.Image = img;
                pictureBox.ClientSize = new Size(flowLayoutPanel_MathImg.Width-25, flowLayoutPanel_MathImg.Height);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                flowLayoutPanel_MathImg.Controls.Add(pictureBox);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                MessageBox.Show("Problem z wczytaniem obrazka ze ścieżki -> " + pathMathImg, "Błąd", MessageBoxButtons.OK);
            }
        }

        private void Button_SaveData_Click(object sender, EventArgs e) {

        }

        private void CheckBox_TurnOffVeto_Click(object sender, EventArgs e) {
            int selectedIndex = listBox_CriteriaToChose.SelectedIndex;
            try {
                if (checkBox_TurnOffVeto.Checked) {
                    taskElectreIII.ListaWartProgKryt_SetValue(selectedIndex, 2, 0, 999999999.9);
                    taskElectreIII.ListaWartProgKryt_SetValue(selectedIndex, 2, 1, 999999999.9);
                    textBox_ProgAlfaV.Enabled = false;
                    textBox_ProgAlfaV.Clear();
                    textBox_ProgBetaV.Enabled = false;
                    textBox_ProgBetaV.Clear();
                }
                else {
                    taskElectreIII.ListaWartProgKryt_SetValue(selectedIndex, 2, 0, 0.0);
                    taskElectreIII.ListaWartProgKryt_SetValue(selectedIndex, 2, 1, 0.0);
                    textBox_ProgAlfaV.Enabled = true;
                    textBox_ProgBetaV.Enabled = true;
                    textBox_ProgAlfaV.Text = "0,0";
                    textBox_ProgBetaV.Text = "0,0";
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Coś poszło nie tak. Sprawdź poprawność wprowadzonych danych a następnie wybierz kryterium z listy.", "Wystąpił błąd", MessageBoxButtons.OK); 
                Console.WriteLine(ex);
                if (checkBox_TurnOffVeto.Checked) {
                    checkBox_TurnOffVeto.Checked = false;
                }
                else {
                    checkBox_TurnOffVeto.Checked = true;
                }
                taskElectreIII.ListaWartProgKryt_SetValue(selectedIndex, 2, 0, 0.0);
                taskElectreIII.ListaWartProgKryt_SetValue(selectedIndex, 2, 1, 0.0);
                textBox_ProgAlfaV.Text = "0,0";
                textBox_ProgBetaV.Text = "0,0";
            }
        }

        private void CheckBox_CheckAllOptions_CheckedChanged(object sender, EventArgs e) {
            if(checkBox_CheckAllOptions.Checked) {
                checkBox_ConcordanceMatrix.Checked = true;
                checkBox_ConcordanceSet.Checked = true;
                checkBox_CredibilityMatrix.Checked = true;
                checkBox_NonConcordanceSets.Checked = true;
                checkBox_OutrankingSets.Checked = true;
                checkBox_Rankings.Checked = true;
                checkBox_RatingMatrix.Checked = true;
                checkBox_SetEqualityMatrix.Checked = true;
                checkBox_TopDownDistillation.Checked = true;
                checkBox_UpwardDistillation.Checked = true;
            }
            else {
                checkBox_ConcordanceMatrix.Checked = false;
                checkBox_ConcordanceSet.Checked = false;
                checkBox_CredibilityMatrix.Checked = false;
                checkBox_NonConcordanceSets.Checked = false;
                checkBox_OutrankingSets.Checked = false;
                checkBox_Rankings.Checked = false;
                checkBox_RatingMatrix.Checked = false;
                checkBox_SetEqualityMatrix.Checked = false;
                checkBox_TopDownDistillation.Checked = false;
                checkBox_UpwardDistillation.Checked = false;
            }
        }

        public void AddTabPage(Object[,] matrixData, String namePage) {

            Console.WriteLine("LAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            TabPage tabPage = new TabPage();
            tabPage.Text = namePage;

            DataGridView dataGridView = new DataGridView();
            dataGridView.Size = new Size(690, 350);
            DataTable dataTable = new DataTable();

            /* tu mamy liczbaKryteriow+1 to +1 jest dlatego, że pierwsza kolumna (o indeksie 0) jest kolumną nazw 
            w tej pętli dodajemy nazwy kolumn do listy im dedykowanej */

            for (int licz = 0; licz < (matrixData.GetLength(1) + 1); licz++) {
                DataColumn column = new DataColumn();
                column.ColumnName = "A" + licz;
                dataTable.Columns.Add(column);
            }

            int x;
            if ("Rank. Zstep.".Equals(namePage) || "Rank. Wstep.".Equals(namePage) || "Rank. Final.".Equals(namePage)) {
                dataTable.Columns[0].ColumnName = "Wariant";
                x = 1;
            }
            else {
                dataTable.Columns[0].ColumnName = "X";
                x = 0;
            }

            for (int y = x; y < matrixData.GetLength(0); y++) {
                DataRow dataRow = dataTable.NewRow();
                List<string> row = new List<string>();

                for (int z = 0; z < matrixData.GetLength(1) + 1; z++) {
                    if (z == 0) {
                        if ("Rank. Zstep.".Equals(namePage) || "Rank. Wstep.".Equals(namePage) || "Rank. Final.".Equals(namePage)) {
                            row.Add("Pozycja");
                        }
                        else
                        {
                            row.Add("A" + (y + 1));
                        }
                    }
                    else {
                        row.Add(matrixData[y, z - 1].ToString());
                        Console.WriteLine("WARTOSC MATRIXA = " + matrixData[y, z - 1]);
                        Console.WriteLine("ROW = " + row[z]);
                    }
                }
                dataTable.Rows.Add(row);
            }

            dataGridView.DataSource = dataTable;
            tabPage.Controls.Add(dataGridView);
            tabControl_LeaderBoards.TabPages.Add(tabPage);
        }


        Double zmiennaHelp;
        public void AddTabPage(Double[,] matrixData, string namePage, List<Int32> roboczaListaNumerowOpcji) {
            TabPage tabPage = new TabPage();
            tabPage.Text = namePage;

            DataGridView dataGridView = new DataGridView();
            dataGridView.Size = new Size(690, 350);
            DataTable dataTable = new DataTable();

            Boolean bool1 = namePage.Contains("Ocen");
            Boolean bool2 = namePage.Contains("Finalna");

            /* tu mamy liczbaKryteriow+1 to +1 jest dlatego, że pierwsza kolumna (o indeksie 0) jest kolumną nazw 
            w tej pętli dodajemy nazwy kolumn do listy im dedykowanej */
            for (int licz = 0; licz < matrixData.GetLength(0) + 1; licz++) {
                DataColumn column = new DataColumn();
                if (bool1 && licz > 0 && licz < matrixData.GetLength(0) + 1) {
                    //columnNamesView.add("A" + (roboczaListaNumerowOpcji.get(licz - 1) + 1));
/*                    int liczenie = roboczaListaNumerowOpcji[licz - 1] + 1;
                    dataGridView.Columns.Add("","A" + (roboczaListaNumerowOpcji[licz - 1] + 1).ToString());*/
                    column.ColumnName = "A" + (roboczaListaNumerowOpcji[licz - 1] + 1).ToString();
                    dataTable.Columns.Add(column);
                }
                else {
                    column.ColumnName = "A" + licz;
                    dataTable.Columns.Add(column);
                    //columnNamesView.add("A" + licz);
                }
            }

            dataTable.Columns[0].ColumnName = "X";

            for (int y = 0; y < matrixData.GetLength(1); y++) {

                //ObservableList<String> row = FXCollections.observableArrayList();
                DataRow dataRow = dataTable.NewRow();
                List<string> row = new List<string>();

                for (int z = 0; z < matrixData.GetLength(1) + 1; z++) {
                    if (z == 0) {
                        if (bool1) {
                            switch (y) {
                                case 0:
                                    row.Add("Power");
                                    break;

                                case 1:
                                    row.Add("Weakness");
                                    break;

                                case 2:
                                    row.Add("Qualification");
                                    break;
                            }
                        }
                        else {
                            row.Add("A" + (y + 1));
                        }
                    }
                    else {
                        if (bool2) {
                            zmiennaHelp = matrixData[y, z - 1];
                            switch (matrixData[y, z - 1]) {
                                case -1.0:
                                    row.Add("\u20B1");
                                    break;
                                case 0.0:
                                    row.Add("I");
                                    break;
                                case 1.0:
                                    row.Add("\u03A1");
                                    break;
                                case 2.0:
                                    row.Add("R");
                                    break;
                            }
                        }
                        else {
                            row.Add(matrixData[y, z - 1].ToString());
                        }
                    }
                }

                dataTable.Rows.Add(row);
            }

            dataGridView.DataSource = dataTable;
            tabPage.Controls.Add(dataGridView);
            tabControl_LeaderBoards.TabPages.Add(tabPage);
        }


        Match matchInt;
        Match matchDouble;
        int columnIndex;
        string valueOfSelectedCell;

        private void dataGridView_Matrix_CellEndEdit(object sender, DataGridViewCellEventArgs dataGridEvent) {
            if (dataGridView_Matrix.CurrentCell.ColumnIndex > 0) {
                columnIndex = dataGridView_Matrix.CurrentCell.ColumnIndex;
                valueOfSelectedCell = dataGridView_Matrix.Rows[dataGridEvent.RowIndex].Cells[columnIndex].Value.ToString();
                matchDouble = Regex.Match(valueOfSelectedCell, @"^-?[0-9]+\,[0-9]+$", RegexOptions.IgnoreCase);
                matchInt = Regex.Match(valueOfSelectedCell, @"^-?[0-9]+$", RegexOptions.IgnoreCase);

                if (matchDouble.Success) {
                    Console.WriteLine("wartosc rowindex = "+ dataGridEvent.RowIndex+" + 9 = "+(dataGridEvent.RowIndex+9));
                    if (dataGridEvent.RowIndex > 2) {
                        taskElectreIII.TabelaMatrix_SetValue((dataGridEvent.RowIndex) + 6, columnIndex - 1, Double.Parse(valueOfSelectedCell));
                    }
                } else if (matchInt.Success) {
                    if (dataGridEvent.RowIndex > 2) {
                        taskElectreIII.TabelaMatrix_SetValue((dataGridEvent.RowIndex) + 6, columnIndex - 1, Double.Parse(valueOfSelectedCell));
                    }
                }
                else {
                    valueOfSelectedCell = "0.00";
                    dataGridView_Matrix.Rows[dataGridEvent.RowIndex].Cells[columnIndex].Value = "0,00";
                    MessageBox.Show("Wprowadzono niedozwolone znaki w wybraną komórkę." +
                        "\n\nDane należy wprowadzić w formacie CYFRY,CYFRY oraz opcjonalnie można dodać na początku znak ujemności." +
                        "\n\nSpróbuj ponownie.", "Błąd danych", MessageBoxButtons.OK);
                }
            }
        }

        private void listBox_CriteriaToChose_SelectedIndexChanged(object sender, EventArgs e) {
            int selectedIndex = listBox_CriteriaToChose.SelectedIndex;
            Console.WriteLine("wybrany index = "+selectedIndex);

            if (selectedIndex >= 0) {
                if (taskElectreIII.ListaWartProgKryt_GetValue(selectedIndex, 2, 0) != 999999999.9) {
                    checkBox_TurnOffVeto.Checked = false;
                } else {
                    checkBox_TurnOffVeto.Checked = true;
                }
                textBox_ProgAlfaQ.Text = taskElectreIII.ListaWartProgKryt_GetValue(selectedIndex, 0, 0).ToString();
                textBox_ProgAlfaP.Text = taskElectreIII.ListaWartProgKryt_GetValue(selectedIndex, 1, 0).ToString();
                if (!checkBox_TurnOffVeto.Checked) {
                    textBox_ProgAlfaV.Text = taskElectreIII.ListaWartProgKryt_GetValue(selectedIndex, 2, 0).ToString();
                    textBox_ProgBetaV.Text = taskElectreIII.ListaWartProgKryt_GetValue(selectedIndex, 2, 1).ToString();
                    textBox_ProgAlfaV.Enabled = true;
                    textBox_ProgBetaV.Enabled = true;
                } else {
                    textBox_ProgAlfaV.Enabled = false;
                    textBox_ProgBetaV.Enabled = false;
                    textBox_ProgAlfaV.Clear();
                    textBox_ProgBetaV.Clear();
                }
                textBox_ProgBetaQ.Text = taskElectreIII.ListaWartProgKryt_GetValue(selectedIndex, 0, 1).ToString();
                textBox_ProgBetaP.Text = taskElectreIII.ListaWartProgKryt_GetValue(selectedIndex, 1, 1).ToString();
            };
        }

        private void textBox_Alternatives_KeyPress(object sender, KeyEventArgs keyEvent) {
            if (keyEvent.KeyCode.Equals(Keys.Enter)) {
                if (TextBoxValidationInt(textBox_Alternatives, keyEvent, 1)) {
                    taskElectreIII.NumberOfAlternatives = Int32.Parse(textBox_Alternatives.Text);
                }
            } 
        }

        private void TextBox_Criteria_KeyDown(object sender, KeyEventArgs keyEvent) {
            if (keyEvent.KeyCode.Equals(Keys.Enter)) {
                if (TextBoxValidationInt(textBox_Criteria, keyEvent, 1)) {
                    taskElectreIII.NumberOfCriterias = Int32.Parse(textBox_Criteria.Text);
                }
            } 
        }

        private void TextBox_DecimalPlaces_KeyDown(object sender, KeyEventArgs keyEvent) {
            if (keyEvent.KeyCode.Equals(Keys.Enter)) {
                if (TextBoxValidationInt(textBox_DecimalPlaces, keyEvent, 0)) {
                    taskElectreIII.MiejscPoPrzecinku = Int32.Parse(textBox_DecimalPlaces.Text);
                };
            }
        }

        private void TextBox_ProgAlfaQ_KeyDown(object sender, KeyEventArgs keyEvent) {
            if (keyEvent.KeyCode.Equals(Keys.Enter)) {
                if (TextBoxValidationDouble(textBox_ProgAlfaQ, keyEvent)) {
                    EventEnterForThresholds(textBox_ProgAlfaQ, 0, 0);
                };
            }
        }

        private void TextBox_ProgBetaQ_KeyDown(object sender, KeyEventArgs keyEvent) {
            if (keyEvent.KeyCode.Equals(Keys.Enter)) {
                if (TextBoxValidationDouble(textBox_ProgBetaQ, keyEvent)) {
                    EventEnterForThresholds(textBox_ProgBetaQ, 0, 1);
                };
            }
        }

        private void TextBox_ProgAlfaP_KeyDown(object sender, KeyEventArgs keyEvent) {
            if (keyEvent.KeyCode.Equals(Keys.Enter)) {
                if (TextBoxValidationDouble(textBox_ProgAlfaP, keyEvent)) {
                    EventEnterForThresholds(textBox_ProgAlfaP, 1, 0);
                };
            }
        }

        private void TextBox_ProgBetaP_KeyDown(object sender, KeyEventArgs keyEvent) {
            if (keyEvent.KeyCode.Equals(Keys.Enter)) {
                if (TextBoxValidationDouble(textBox_ProgBetaP, keyEvent)) {
                    EventEnterForThresholds(textBox_ProgBetaP, 1, 1);
                };
            }
        }

        private void TextBox_ProgAlfaV_KeyDown(object sender, KeyEventArgs keyEvent) {
            if (keyEvent.KeyCode.Equals(Keys.Enter)) {
                if (TextBoxValidationDouble(textBox_ProgAlfaV, keyEvent)) {
                    EventEnterForThresholds(textBox_ProgAlfaV, 2, 0);
                };
            }
        }

        private void TextBox_ProgBetaV_KeyDown(object sender, KeyEventArgs keyEvent) {
            if (keyEvent.KeyCode.Equals(Keys.Enter)) {
                if (TextBoxValidationDouble(textBox_ProgBetaV, keyEvent)) {
                    EventEnterForThresholds(textBox_ProgBetaV, 2, 1);
                };
            }
        }

        private void TextBox_Alfa_KeyDown(object sender, KeyEventArgs keyEvent) {
            if (keyEvent.KeyCode.Equals(Keys.Enter)) {
                if (TextBoxValidationDouble(textBox_Alfa, keyEvent)) {
                    taskElectreIII.Alfa = Double.Parse(textBox_Alfa.Text);
                };
            }
        }

        private void TextBox_Beta_KeyDown(object sender, KeyEventArgs keyEvent) {
            if (keyEvent.KeyCode.Equals(Keys.Enter)) {
                if (TextBoxValidationDouble(textBox_Beta, keyEvent)) {
                    taskElectreIII.Beta = Double.Parse(textBox_Beta.Text);
                };
            }
        }

        public void EventEnterForThresholds(TextBox textBox, int positionOfThreshold, int positionOfSymbol) {
            int index = listBox_CriteriaToChose.SelectedIndex;
            taskElectreIII.ListaWartProgKryt_SetValue(index, positionOfThreshold, positionOfSymbol, Double.Parse(textBox.Text));
            switch(positionOfSymbol) {
                case 0: taskElectreIII.TabelaMatrix_SetValue(positionOfThreshold + 3, index, Double.Parse(textBox.Text)); break;     
                case 1: taskElectreIII.TabelaMatrix_SetValue(positionOfThreshold + 6, index, Double.Parse(textBox.Text)); break;
            }
        }

        public Boolean TextBoxValidationInt(TextBox textBox, KeyEventArgs keyEvent, int caseOption) {
            keyEvent.SuppressKeyPress = true;
            matchInt = Regex.Match(textBox.Text, @"^[0-9]+$", RegexOptions.IgnoreCase);
            ActiveControl = null;
            if (!matchInt.Success) {
                MessageBox.Show("Wystąpił błąd podczas wprowadzania danych.\nW danym polu należy wprowadzić liczby całkowite większe od 0.", "Błąd", MessageBoxButtons.OK);
                textBox.Clear();
                return false;
            } 
            else {
                switch (caseOption) {
                    case 0:
                        if (Int32.Parse(textBox.Text) < 0 || Int32.Parse(textBox.Text) >= 15) {
                            MessageBox.Show("Wystąpił błąd podczas wprowadzania danych.\nW danym polu należy wprowadzić liczbę całkowitą z przedziału 0 - 15.", "Błąd", MessageBoxButtons.OK); 
                            return false; 
                        }
                        else { return true; }
                    case 1:
                        if(Int32.Parse(textBox.Text) != 0) { return true; } 
                        else {
                            MessageBox.Show("Wystąpił błąd podczas wprowadzania danych.\nW danym polu należy wprowadzić liczby całkowite większe od 0.", "Błąd", MessageBoxButtons.OK);
                            return false;
                        }
                }
                return false;
            }
        }

        public Boolean TextBoxValidationDouble(TextBox textBox, KeyEventArgs keyEvent) {
            keyEvent.SuppressKeyPress = true;
            matchDouble = Regex.Match(textBox.Text, @"^-?[0-9]+\,[0-9]+$", RegexOptions.IgnoreCase);
            matchInt = Regex.Match(textBox.Text, @"^-?[0-9]+$", RegexOptions.IgnoreCase);
            ActiveControl = null;
            if (!matchDouble.Success) {
                if (!matchInt.Success) {
                    MessageBox.Show("Wystąpił błąd podczas wprowadzania danych.\nW danym polu można wprowadzać jedynie liczby całkowite lub liczby z wartościami po przecinku z wykorzystaniem przecinka podczas określania wartości w polu.", "Błąd", MessageBoxButtons.OK);
                    textBox.Text = "0,0";
                    return false;
                } else { return true; }
            } else { return true; }
        }

        private void checkBox_ConcordanceSets_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_ConcordanceSet.Checked) { taskElectreIII.CboxConcordanceSetsChecked = true; }
            else { taskElectreIII.CboxConcordanceSetsChecked = false; }
        }

        private void checkBox_ConcordanceMatrix_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_ConcordanceMatrix.Checked) { taskElectreIII.CboxConcordanceMatrixChecked = true; }
            else { taskElectreIII.CboxConcordanceMatrixChecked = false; }
        }

        private void checkBox_NonConcordanceSets_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_NonConcordanceSets.Checked) { taskElectreIII.CboxNonConcordanceSetsChecked = true; }
            else { taskElectreIII.CboxNonConcordanceSetsChecked = false; }
        }

        private void checkBox_OutrankingSets_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_OutrankingSets.Checked) { taskElectreIII.CboxOutrankingSetsChecked = true; }
            else { taskElectreIII.CboxOutrankingSetsChecked = false; }
        }

        private void checkBox_SetEqualityMatrix_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_SetEqualityMatrix.Checked) { taskElectreIII.CboxSetEqualityMatrixChecked = true; }
            else { taskElectreIII.CboxSetEqualityMatrixChecked = false; }
        }

        private void checkBox_CredibilityMatrix_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_CredibilityMatrix.Checked) { taskElectreIII.CboxCredibilityMatrixChecked = true; }
            else { taskElectreIII.CboxCredibilityMatrixChecked = false; }
        }

        private void checkBox_RatingMatrix_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_RatingMatrix.Checked) { taskElectreIII.CboxRatingMatrixChecked = true; }
            else { taskElectreIII.CboxRatingMatrixChecked = false; }
        }

        private void checkBox_TopDownDistillation_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_TopDownDistillation.Checked) { taskElectreIII.CboxTopDownDistillationChecked = true; }
            else { taskElectreIII.CboxTopDownDistillationChecked = false; }
        }

        private void checkBox_UpwardDistillation_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_UpwardDistillation.Checked) { taskElectreIII.CboxUpwardDistillationChecked = true; }
            else { taskElectreIII.CboxUpwardDistillationChecked = false; }
        }

        private void checkBox_Rankings_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_Rankings.Checked) { taskElectreIII.CboxRankingsChecked = true; }
            else { taskElectreIII.CboxRankingsChecked = false; }
        }
    }
}
