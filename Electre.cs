﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace ElectreAp
{
    public partial class Electre : Form {

        public Electre() {
            InitializeComponent();
            textBox_Alfa.Text = taskElectreIII.Alfa.ToString();
            textBox_Beta.Text = taskElectreIII.Beta.ToString();
            textBox_DecimalPlaces.Text = taskElectreIII.MiejscPoPrzecinku.ToString();

            SavingSuccessfulDelegate successFulDelegate = new SavingSuccessfulDelegate(() => { MessageBox.Show("Saving operation got successful", "Information", MessageBoxButtons.OK); });
            SavingSuccessfulEvent += successFulDelegate;
            SavingFailedDelegate failedDelegate = new SavingFailedDelegate(() => { MessageBox.Show("Saving operation got failed! \n\nSomething gone wrong, check data and try again.\nIf something go wrong again contact with IT Specialist", "Information", MessageBoxButtons.OK); });
            SavingFailedEvent += failedDelegate;
        }

        private void UserControl_Load(object sender, EventArgs e) { }


        static ElectreIII taskElectreIII = new ElectreIII();
        int alternatives = 0;
        int criteria = 0;


        private async void Button_CreateTab_Click(object sender, EventArgs e) {

            criteria = Int32.Parse(textBox_Criteria.Text);
            alternatives = Int32.Parse(textBox_Alternatives.Text);

            Task<DataTable> taskCreateUserTab = new Task<DataTable>( () => CreateUserTab());
            // await Task.Run(() => CreateTab());
            taskCreateUserTab.Start();

            dataGridView_Matrix.DataSource = await taskCreateUserTab;
            EstablishDataSourceAndBasicSettings();

           // dataTableBasedOnMatrix = await taskCreateUserTab;
               // dataGridView_Matrix.DataSource = dataTableBasedOnMatrix;
/*                dataGridView_Matrix.Columns[0].ReadOnly = true;
                dataGridView_Matrix.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(202, 202, 202);
                dataGridView_Matrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView_Matrix.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

                listBox_CriteriaToChose.Items.AddRange(taskElectreIII.ColumnNamesDoListy.ToArray());
                listBox_CriteriaToChose.Font = new Font(listBox_CriteriaToChose.Font.Name, 10);
            listBox_CriteriaToChose.HorizontalScrollbar = true;*/
        }

/*        private DataTable LoloAsync()
        {
            return taskElectreIII.CreateDataTableBasedOnMatrix(taskElectreIII.tabelaMatrix, 1, 0);
        }*/


/*        private string cosik()
        {
            Thread.Sleep(3000);
            return "Done";
        }*/



        private DataTable CreateUserTab()
        {

            taskElectreIII.CreateBaseMatrix(alternatives, criteria);

            PreparePropertiesAsync(criteria, taskElectreIII.TabelaMatrix, 1, 0);

           // Task<DataTable> taskCreateDataTable = taskElectreIII.CreateDataTableAsync(1, 0);
           // taskCreateDataTable.Start();

            // dataTableBasedOnMatrix = await taskCreateDataTable;
            //dataTableBasedOnMatrix = await taskElectreIII.CreateDataTableBasedOnMatrixAsync(matrix, colAdd, rowAdd, algorithmDelegate);

            //return taskCreateDataTable;
            return taskElectreIII.CreateDataTableAsync(1, 0);

            //dataGridView_Matrix.DataSource = await taskElectreIII.CreateDataTableBasedOnMatrixAsync(taskElectreIII.tabelaMatrix, 1, 0); //dataTableBasedOnMatrix;
            //Task<string> task = new Task<string>(cosik);
            //task.Start();
            //label_Criteria.Text = await task;

           // dataGridView_Matrix.DataSource = await task;
/*            dataGridView_Matrix.Columns[0].ReadOnly = true;
            dataGridView_Matrix.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(202, 202, 202);
            dataGridView_Matrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView_Matrix.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;*/

            listBox_CriteriaToChose.Items.AddRange(taskElectreIII.ColumnNamesDoListy.ToArray());
            listBox_CriteriaToChose.Font = new Font(listBox_CriteriaToChose.Font.Name, 10);
            listBox_CriteriaToChose.HorizontalScrollbar = true;
        }

        DataTable dataTableBasedOnMatrix;

        public async Task PreparePropertiesAsync(int criteria, Double[,] matrix, int colAdd, int rowAdd) {
            //Task task = taskElectreIII.CreateColumnNames(criteria, colAdd);

            taskElectreIII.ColumnNamesDoListy = await taskElectreIII.CreateColumnNamesAsync(criteria, colAdd);
            taskElectreIII.ListaWartProgKryt = await taskElectreIII.CreateListOfValueThresholdsAsync(criteria, matrix);
            //taskElectreIII.CreateListOfValueThresholds(criteria, matrix);
            //dataTableBasedOnMatrix = await taskElectreIII.CreateDataTableBasedOnMatrixAsync(matrix, colAdd, rowAdd);
        }

        private async Task EstablishDataSourceAndBasicSettings()
        {
           // dataGridView_Matrix.DataSource = dataTableBasedOnMatrix;
            dataGridView_Matrix.Columns[0].ReadOnly = true;
            dataGridView_Matrix.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(202, 202, 202);
            dataGridView_Matrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView_Matrix.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            listBox_CriteriaToChose.Items.AddRange(await Task.Run(() => taskElectreIII.ColumnNamesDoListy.ToArray()));

            //listBox_CriteriaToChose.Items.AddRange(taskElectreIII.ColumnNamesDoListy.ToArray());
            listBox_CriteriaToChose.Font = new Font(listBox_CriteriaToChose.Font.Name, 10);
            listBox_CriteriaToChose.HorizontalScrollbar = true;
        }

        static string dialogPath = "";

        private async void Button_ReadTab_Click(object sender, EventArgs e) {

            dialogPath = OpenDialogGetPathFile();

            exelManager = new ExcelManaging();

            processValue = 0;
            processValueMax = 0;

            var progress = new Progress<int>(percent => { progressBar1.Value = percent; label1.Text = (percent + "%"); });

            await Task.Run(() => { ReadDataFromFileProcess(progress); PreparePropertiesAsync(criteria, taskElectreIII.TabelaMatrix, 1, 0); taskElectreIII.CreateDataTableAsync(1, 0); });
            //await ReadDataFromFileProcess(progress);

            /*            criteria = taskElectreIII.tabelaMatrix.GetLength(1);
                        alternatives = taskElectreIII.tabelaMatrix.GetLength(0);*/
            //  await Task.Run( () => PreparePropertiesAsync(criteria, taskElectreIII.tabelaMatrix, 1, 0));
            // await PreparePropertiesAsync(criteria, taskElectreIII.TabelaMatrix, 1, 0);

            //await Task.Run(() => taskElectreIII.CreateDataTableAsync(1, 0));

            Task<DataTable> taskReadMatrixToDataTable = new Task<DataTable>(() => taskElectreIII.CreateDataTableAsync(1, 0));
            // await Task.Run(() => CreateTab());
            taskReadMatrixToDataTable.Start();

            dataGridView_Matrix.DataSource = await taskReadMatrixToDataTable;
            EstablishDataSourceAndBasicSettings();

            label1.Text = "\u2713";

            progressBar1.Value = 0;
        }


        public string OpenDialogGetPathFile() {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = "C:\\Users\\MaRkOs\\Dokumenty";
                openFileDialog.Filter = "Exel files (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = openFileDialog.FileName;
                    return filePath;
                }
                else {
                    return string.Empty;
                }
            }
        }


        public string OpenDialogGetPathDirectory() {
            using (FolderBrowserDialog openBrowserDialog = new FolderBrowserDialog()) {
                openBrowserDialog.SelectedPath = "C:\\Users\\MaRkOs\\Dokumenty";

                if (openBrowserDialog.ShowDialog() == DialogResult.OK) {
                    string path = openBrowserDialog.SelectedPath;
                    return path;
                }
                else {
                    return string.Empty;
                }
            }
        }

        static ExcelManaging exelManager;

        private async void Button_SaveTab_Click(object sender, EventArgs e) {
            dialogPath = OpenDialogGetPathDirectory();
            exelManager = new ExcelManaging();

            processValueMax = taskElectreIII.TabelaMatrix.GetLength(0) * taskElectreIII.TabelaMatrix.GetLength(1);

            var progress = new Progress<int>( percent => { progressBar1.Value = percent; label1.Text = (percent + "%"); });

            await Task.Run(() => SaveTableToFileProcess(progress));

            label1.Text = "\u2713";

            progressBar1.Value = 0;

            SavingSuccessfulEvent();
        }


        List<Int32> lul = new List<Int32>();

        private void Button_Calculate_Click(object sender, EventArgs e) {
            tabControl_LeaderBoards.TabPages.Clear();
            //Reset(2);

            try
            {
                if (textBox_Alfa.Text != taskElectreIII.Beta.ToString()) {
                    //if (TextBoxValidationDouble(textBox_Alfa, null) && textBox_Alfa.Text != taskElectreIII.Beta.ToString()) {
                    taskElectreIII.Alfa = Double.Parse(textBox_Alfa.Text);
                }

                if (textBox_Beta.Text != taskElectreIII.Alfa.ToString()) {
                    //if (TextBoxValidationDouble(textBox_Beta, null) && textBox_Beta.Text != taskElectreIII.Alfa.ToString()) {
                    taskElectreIII.Beta = Double.Parse(textBox_Beta.Text);
                }

                if (textBox_DecimalPlaces.Text != taskElectreIII.MiejscPoPrzecinku.ToString()) {
                    //if (TextBoxValidationInt(textBox_DecimalPlaces, null, 0) && textBox_DecimalPlaces.Text != taskElectreIII.MiejscPoPrzecinku.ToString()) {
                    taskElectreIII.MiejscPoPrzecinku = Int32.Parse(textBox_DecimalPlaces.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("W polach Alfa, Beta i Miejsca po przecinku można wprowadzać tylko cyfry! \n Ponadto dla Alfa i Beta używamy przecinka a nie kropki", "Błąd", MessageBoxButtons.OK);
                Console.WriteLine(ex);
            }

            taskElectreIII.DoCalculations();
            taskElectreIII.PreparedImagesAndShowCollections();

            //wyświetlamy wszystkie utworzone dataTable i umieszczone w liście ListOfDataTable
            foreach (DataTable dataTable in taskElectreIII.ListOfDataTable) {
                AddTabPage(dataTable, dataTable.TableName);
            }

            foreach (String pathMathImg in taskElectreIII.ListOfPathsImages) {
                ShowMathImage(pathMathImg);
            }
        }


        public void ShowMathImage(String pathMathImg) {
            try {
                PictureBox pictureBox = new PictureBox();
                Image img = Image.FromFile(pathMathImg);
                pictureBox.Image = img;
                pictureBox.ClientSize = new Size(flowLayoutPanel_MathImg.Width - 25, flowLayoutPanel_MathImg.Height);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                flowLayoutPanel_MathImg.Controls.Add(pictureBox);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                MessageBox.Show("Problem z wczytaniem obrazka ze ścieżki -> " + pathMathImg, "Błąd", MessageBoxButtons.OK);
            }
        }


        private delegate void SavingSuccessfulDelegate();

        private event SavingSuccessfulDelegate SavingSuccessfulEvent;

        private delegate void SavingFailedDelegate();

        private event SavingFailedDelegate SavingFailedEvent;

        private void SaveTableToFileProcess(IProgress<int> progress) {
            try
            {
                exelManager.SaveTableToExelFile(dialogPath + @"ElectreTab.xlsx", taskElectreIII.TabelaMatrix, ref processValue, ref processValueMax, progress);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                SavingFailedEvent();
            }
        }

        private async Task ReadDataFromFileProcess(IProgress<int> progress) {
            taskElectreIII.TabelaMatrix = exelManager.ReadTableFromFileToMatrix(dialogPath, out taskElectreIII.tabelaMatrix, ref taskElectreIII.numberOfAlternatives, ref taskElectreIII.numberOfCriterias, ref processValue, ref processValueMax, progress);
            criteria = taskElectreIII.tabelaMatrix.GetLength(1);
            alternatives = taskElectreIII.tabelaMatrix.GetLength(0);
        }

        private void SaveDataToFileProcess(IProgress<int> progress) {
            exelManager.SaveDataToExelFile(dialogPath + @"ElectreData.xlsx", taskElectreIII.TabelaMatrix, taskElectreIII.ConcordanceMatrix, taskElectreIII.CredibilityMatrix, taskElectreIII.ListaZbiorowZgodnosci, taskElectreIII.ListaZbiorowNieZgodnosci, taskElectreIII.ListaZbiorowPrzewyzszania, taskElectreIII.ListaZstepMacierzyOcen, taskElectreIII.ListaWstepMacierzyOcen, taskElectreIII.FinalRanking, taskElectreIII.TopDownRanking, taskElectreIII.UpwardRanking, taskElectreIII.FinalRankingMatrix, taskElectreIII, ref processValue, ref processValueMax, progress);
        }

        private async void Button_SaveData_Click(object sender, EventArgs e) {

            dialogPath = OpenDialogGetPathDirectory();
            exelManager = new ExcelManaging();

            try {
                processValue = 0;
                processValueMax = 12;

                var progress = new Progress<int>(percent => { progressBar1.Value = percent; label1.Text = (percent + "%"); } );

                await Task.Run(() => SaveDataToFileProcess(progress));

                label1.Text = "\u2713";

                progressBar1.Value = 0;

                SavingSuccessfulEvent();

            }
            catch (Exception ex) {
                SavingFailedEvent();
                Console.WriteLine(ex);
            }
        }


        private void CheckBox_TurnOffVeto_Click(object sender, EventArgs e) {
            int selectedIndex = listBox_CriteriaToChose.SelectedIndex;
            try {
                if (checkBox_TurnOffVeto.Checked) {
                    taskElectreIII.ListaWartProgKryt[selectedIndex, 2, 0] = 999999999.9;
                    taskElectreIII.ListaWartProgKryt[selectedIndex, 2, 1] = 999999999.9;
                    textBox_ProgAlfaV.Enabled = false;
                    textBox_ProgAlfaV.Clear();
                    textBox_ProgBetaV.Enabled = false;
                    textBox_ProgBetaV.Clear();
                }
                else {
                    taskElectreIII.ListaWartProgKryt[selectedIndex, 2, 0] = 0.0;
                    taskElectreIII.ListaWartProgKryt[selectedIndex, 2, 1] = 0.0;
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
                taskElectreIII.ListaWartProgKryt[selectedIndex, 2, 0] = 0.0;
                taskElectreIII.ListaWartProgKryt[selectedIndex, 2, 1] = 0.0;
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


        public void AddTabPage(DataTable dataTable, String namePage) {
            TabPage tabPage = new TabPage();
            tabPage.Text = namePage;

            DataGridView dataGridView = new DataGridView();
            dataGridView.Size = new Size(690, 350);
            
            dataGridView.DataSource = dataTable;
            dataGridView.ReadOnly = true;
            dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(202, 202, 202);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
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

                if (matchDouble.Success || matchInt.Success) {
                    Console.WriteLine("wartosc rowindex = "+ dataGridEvent.RowIndex+" + 9 = "+(dataGridEvent.RowIndex+9));
                    if (dataGridEvent.RowIndex > 2) {
                        Console.WriteLine(taskElectreIII.TabelaMatrix.GetLength(0) + ","+ taskElectreIII.TabelaMatrix.GetLength(1));

                        // STARE taskElectreIII.TabelaMatrix[columnIndex - 1, (dataGridEvent.RowIndex) + 6] = Double.Parse(valueOfSelectedCell);
                        taskElectreIII.TabelaMatrix[(dataGridEvent.RowIndex) + 6, columnIndex - 1] = Double.Parse(valueOfSelectedCell);
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
                if (taskElectreIII.ListaWartProgKryt[selectedIndex, 2, 0] != 999999999.9) {
                    checkBox_TurnOffVeto.Checked = false;
                } else {
                    checkBox_TurnOffVeto.Checked = true;
                }
                textBox_ProgAlfaQ.Text = taskElectreIII.ListaWartProgKryt[selectedIndex, 0, 0].ToString();
                textBox_ProgAlfaP.Text = taskElectreIII.ListaWartProgKryt[selectedIndex, 1, 0].ToString();
                if (!checkBox_TurnOffVeto.Checked) {
                    textBox_ProgAlfaV.Text = taskElectreIII.ListaWartProgKryt[selectedIndex, 2, 0].ToString();
                    textBox_ProgBetaV.Text = taskElectreIII.ListaWartProgKryt[selectedIndex, 2, 1].ToString();
                    textBox_ProgAlfaV.Enabled = true;
                    textBox_ProgBetaV.Enabled = true;
                } else {
                    textBox_ProgAlfaV.Enabled = false;
                    textBox_ProgBetaV.Enabled = false;
                    textBox_ProgAlfaV.Clear();
                    textBox_ProgBetaV.Clear();
                }
                textBox_ProgBetaQ.Text = taskElectreIII.ListaWartProgKryt[selectedIndex, 0, 1].ToString();
                textBox_ProgBetaP.Text = taskElectreIII.ListaWartProgKryt[selectedIndex, 1, 1].ToString();
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
            taskElectreIII.ListaWartProgKryt[index, positionOfThreshold, positionOfSymbol] = Double.Parse(textBox.Text);
            switch(positionOfSymbol) {
                case 0: taskElectreIII.TabelaMatrix[positionOfThreshold + 3, index] = Double.Parse(textBox.Text); break;
                case 1: taskElectreIII.TabelaMatrix[positionOfThreshold + 6, index] = Double.Parse(textBox.Text); break;
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

        static int processValue = 0;
        static int processValueMax = 12;
    }
}
