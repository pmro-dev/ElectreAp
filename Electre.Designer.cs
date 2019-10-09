﻿using System.Windows.Forms;

namespace ElectreAp
{
    partial class UserControl
    {
/*        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                label_Alfa1.Text = "\\u03B1";
                label_Alfa2.Text = "\\u03B1";
                label_Alfa3.Text = "\\u03B1";
                label_Alfa4.Text = "\\u03B1";

                label_Beta1.Text = "\u03B2";
                label_Beta2.Text = "\u03B2";
                label_Beta3.Text = "\u03B2";
                label_Beta4.Text = "\u03B2";

                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region Kod wygenerowany przez Projektanta składników

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_CreateTab = new System.Windows.Forms.Button();
            this.button_ReadTab = new System.Windows.Forms.Button();
            this.button_Calculate = new System.Windows.Forms.Button();
            this.button_SaveTab = new System.Windows.Forms.Button();
            this.button_SaveData = new System.Windows.Forms.Button();
            this.textBox_Alternatives = new System.Windows.Forms.TextBox();
            this.textBox_Beta4 = new System.Windows.Forms.TextBox();
            this.textBox_Alfa4 = new System.Windows.Forms.TextBox();
            this.textBox_Beta3 = new System.Windows.Forms.TextBox();
            this.textBox_Beta2 = new System.Windows.Forms.TextBox();
            this.textBox_Beta1 = new System.Windows.Forms.TextBox();
            this.textBox_Alfa3 = new System.Windows.Forms.TextBox();
            this.textBox_Alfa2 = new System.Windows.Forms.TextBox();
            this.textBox_Alfa1 = new System.Windows.Forms.TextBox();
            this.textBox_Criteria = new System.Windows.Forms.TextBox();
            this.label_Alternatives = new System.Windows.Forms.Label();
            this.label_Criteria = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Alfa1 = new System.Windows.Forms.Label();
            this.label_Alfa2 = new System.Windows.Forms.Label();
            this.label_Alfa3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_Beta1 = new System.Windows.Forms.Label();
            this.label_Beta2 = new System.Windows.Forms.Label();
            this.label_Beta3 = new System.Windows.Forms.Label();
            this.listView_CriteriaToChose = new System.Windows.Forms.ListView();
            this.label_Alfa4 = new System.Windows.Forms.Label();
            this.label_Beta4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_DecimalPlaces = new System.Windows.Forms.TextBox();
            this.panel_ChosingOptionsWithCheckBoxes = new System.Windows.Forms.Panel();
            this.checkBox_TopDownDistillation = new System.Windows.Forms.CheckBox();
            this.checkBox_UpwardDistillation = new System.Windows.Forms.CheckBox();
            this.checkBox_Rankings = new System.Windows.Forms.CheckBox();
            this.checkBox_CompatibilityMatrix = new System.Windows.Forms.CheckBox();
            this.checkBox_NonComplianceSets = new System.Windows.Forms.CheckBox();
            this.checkBox_OutrankingSets = new System.Windows.Forms.CheckBox();
            this.checkBox_SetEqualityMatrix = new System.Windows.Forms.CheckBox();
            this.checkBox_RatingMatrix = new System.Windows.Forms.CheckBox();
            this.checkBox_CredibilityMatrix = new System.Windows.Forms.CheckBox();
            this.checkBox_ComplianceSet = new System.Windows.Forms.CheckBox();
            this.checkBox_CheckAllOptions = new System.Windows.Forms.CheckBox();
            this.label_ChosingOptionsWithCheckBoxes = new System.Windows.Forms.Label();
            this.checkBox_TurnOffVeto = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl_LeaderBoards = new System.Windows.Forms.TabControl();
            this.groupBox_ForPanelWithImg = new System.Windows.Forms.GroupBox();
            this.panel_WithScrllOptAndImg = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_BasicMatrix = new System.Windows.Forms.TableLayoutPanel();
            this.panel_ChosingOptionsWithCheckBoxes.SuspendLayout();
            this.groupBox_ForPanelWithImg.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_CreateTab
            // 
            this.button_CreateTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.button_CreateTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CreateTab.ForeColor = System.Drawing.SystemColors.Window;
            this.button_CreateTab.Location = new System.Drawing.Point(240, 16);
            this.button_CreateTab.Name = "button_CreateTab";
            this.button_CreateTab.Size = new System.Drawing.Size(105, 35);
            this.button_CreateTab.TabIndex = 0;
            this.button_CreateTab.Text = "Utworz Tabele";
            this.button_CreateTab.UseVisualStyleBackColor = false;
            this.button_CreateTab.Click += new System.EventHandler(this.Button_CreateTab_Click);
            // 
            // button_ReadTab
            // 
            this.button_ReadTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.button_ReadTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ReadTab.ForeColor = System.Drawing.SystemColors.Window;
            this.button_ReadTab.Location = new System.Drawing.Point(352, 16);
            this.button_ReadTab.Name = "button_ReadTab";
            this.button_ReadTab.Size = new System.Drawing.Size(111, 35);
            this.button_ReadTab.TabIndex = 1;
            this.button_ReadTab.Text = "Wczytaj Tabele";
            this.button_ReadTab.UseVisualStyleBackColor = false;
            this.button_ReadTab.Click += new System.EventHandler(this.Button_ReadTab_Click);
            // 
            // button_Calculate
            // 
            this.button_Calculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.button_Calculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Calculate.ForeColor = System.Drawing.SystemColors.Window;
            this.button_Calculate.Location = new System.Drawing.Point(352, 56);
            this.button_Calculate.Name = "button_Calculate";
            this.button_Calculate.Size = new System.Drawing.Size(111, 35);
            this.button_Calculate.TabIndex = 2;
            this.button_Calculate.Text = "Oblicz";
            this.button_Calculate.UseVisualStyleBackColor = false;
            this.button_Calculate.Click += new System.EventHandler(this.Button_Calculate_Click);
            // 
            // button_SaveTab
            // 
            this.button_SaveTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.button_SaveTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SaveTab.ForeColor = System.Drawing.SystemColors.Window;
            this.button_SaveTab.Location = new System.Drawing.Point(240, 56);
            this.button_SaveTab.Name = "button_SaveTab";
            this.button_SaveTab.Size = new System.Drawing.Size(105, 35);
            this.button_SaveTab.TabIndex = 3;
            this.button_SaveTab.Text = "Zapisz Tabele";
            this.button_SaveTab.UseVisualStyleBackColor = false;
            this.button_SaveTab.Click += new System.EventHandler(this.Button_SaveTab_Click);
            // 
            // button_SaveData
            // 
            this.button_SaveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.button_SaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SaveData.ForeColor = System.Drawing.SystemColors.Window;
            this.button_SaveData.Location = new System.Drawing.Point(308, 287);
            this.button_SaveData.Name = "button_SaveData";
            this.button_SaveData.Size = new System.Drawing.Size(149, 35);
            this.button_SaveData.TabIndex = 4;
            this.button_SaveData.Text = "Zapisz Dane";
            this.button_SaveData.UseVisualStyleBackColor = false;
            this.button_SaveData.Click += new System.EventHandler(this.Button_SaveData_Click);
            // 
            // textBox_Alternatives
            // 
            this.textBox_Alternatives.Location = new System.Drawing.Point(67, 49);
            this.textBox_Alternatives.Multiline = true;
            this.textBox_Alternatives.Name = "textBox_Alternatives";
            this.textBox_Alternatives.Size = new System.Drawing.Size(45, 25);
            this.textBox_Alternatives.TabIndex = 5;
            this.textBox_Alternatives.Leave += new System.EventHandler(this.TextBox_Alternatives_FokusLeave);
            // 
            // textBox_Beta4
            // 
            this.textBox_Beta4.Location = new System.Drawing.Point(354, 177);
            this.textBox_Beta4.Multiline = true;
            this.textBox_Beta4.Name = "textBox_Beta4";
            this.textBox_Beta4.Size = new System.Drawing.Size(45, 25);
            this.textBox_Beta4.TabIndex = 7;
            this.textBox_Beta4.Leave += new System.EventHandler(this.TextBox_Beta4_FokusLeave);
            // 
            // textBox_Alfa4
            // 
            this.textBox_Alfa4.Location = new System.Drawing.Point(354, 135);
            this.textBox_Alfa4.Multiline = true;
            this.textBox_Alfa4.Name = "textBox_Alfa4";
            this.textBox_Alfa4.Size = new System.Drawing.Size(45, 25);
            this.textBox_Alfa4.TabIndex = 8;
            this.textBox_Alfa4.Leave += new System.EventHandler(this.TextBox_Alfa4_FokusLeave);
            // 
            // textBox_Beta3
            // 
            this.textBox_Beta3.Location = new System.Drawing.Point(160, 261);
            this.textBox_Beta3.Multiline = true;
            this.textBox_Beta3.Name = "textBox_Beta3";
            this.textBox_Beta3.Size = new System.Drawing.Size(45, 25);
            this.textBox_Beta3.TabIndex = 9;
            this.textBox_Beta3.Leave += new System.EventHandler(this.TextBox_Beta3_FokusLeave);
            // 
            // textBox_Beta2
            // 
            this.textBox_Beta2.Location = new System.Drawing.Point(160, 214);
            this.textBox_Beta2.Multiline = true;
            this.textBox_Beta2.Name = "textBox_Beta2";
            this.textBox_Beta2.Size = new System.Drawing.Size(45, 25);
            this.textBox_Beta2.TabIndex = 10;
            this.textBox_Beta2.Leave += new System.EventHandler(this.TextBox_Beta2_FokusLeave);
            // 
            // textBox_Beta1
            // 
            this.textBox_Beta1.Location = new System.Drawing.Point(160, 137);
            this.textBox_Beta1.Multiline = true;
            this.textBox_Beta1.Name = "textBox_Beta1";
            this.textBox_Beta1.Size = new System.Drawing.Size(45, 25);
            this.textBox_Beta1.TabIndex = 11;
            this.textBox_Beta1.Leave += new System.EventHandler(this.TextBox_Beta1_FokusLeave);
            // 
            // textBox_Alfa3
            // 
            this.textBox_Alfa3.Location = new System.Drawing.Point(67, 261);
            this.textBox_Alfa3.Multiline = true;
            this.textBox_Alfa3.Name = "textBox_Alfa3";
            this.textBox_Alfa3.Size = new System.Drawing.Size(45, 25);
            this.textBox_Alfa3.TabIndex = 12;
            this.textBox_Alfa3.Leave += new System.EventHandler(this.TextBox_Alfa3_FokusLeave);
            // 
            // textBox_Alfa2
            // 
            this.textBox_Alfa2.Location = new System.Drawing.Point(67, 214);
            this.textBox_Alfa2.Multiline = true;
            this.textBox_Alfa2.Name = "textBox_Alfa2";
            this.textBox_Alfa2.Size = new System.Drawing.Size(45, 25);
            this.textBox_Alfa2.TabIndex = 13;
            this.textBox_Alfa2.Leave += new System.EventHandler(this.TextBox_Alfa2_FokusLeave);
            // 
            // textBox_Alfa1
            // 
            this.textBox_Alfa1.Location = new System.Drawing.Point(67, 137);
            this.textBox_Alfa1.Multiline = true;
            this.textBox_Alfa1.Name = "textBox_Alfa1";
            this.textBox_Alfa1.Size = new System.Drawing.Size(45, 25);
            this.textBox_Alfa1.TabIndex = 14;
            this.textBox_Alfa1.Leave += new System.EventHandler(this.TextBox_Alfa1_FokusLeave);
            // 
            // textBox_Criteria
            // 
            this.textBox_Criteria.Location = new System.Drawing.Point(161, 49);
            this.textBox_Criteria.Multiline = true;
            this.textBox_Criteria.Name = "textBox_Criteria";
            this.textBox_Criteria.Size = new System.Drawing.Size(45, 25);
            this.textBox_Criteria.TabIndex = 15;
            this.textBox_Criteria.Leave += new System.EventHandler(this.TextBox_Criteria_FokusLeave);
            // 
            // label_Alternatives
            // 
            this.label_Alternatives.AutoSize = true;
            this.label_Alternatives.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Alternatives.Location = new System.Drawing.Point(51, 21);
            this.label_Alternatives.Name = "label_Alternatives";
            this.label_Alternatives.Size = new System.Drawing.Size(80, 17);
            this.label_Alternatives.TabIndex = 16;
            this.label_Alternatives.Text = "Alternatywy";
            // 
            // label_Criteria
            // 
            this.label_Criteria.AutoSize = true;
            this.label_Criteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Criteria.Location = new System.Drawing.Point(157, 21);
            this.label_Criteria.Name = "label_Criteria";
            this.label_Criteria.Size = new System.Drawing.Size(57, 17);
            this.label_Criteria.TabIndex = 17;
            this.label_Criteria.Text = "Kryteria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(20, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "współczynniki progu równoważności";
            // 
            // label_Alfa1
            // 
            this.label_Alfa1.AutoSize = true;
            this.label_Alfa1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Alfa1.Location = new System.Drawing.Point(37, 139);
            this.label_Alfa1.Name = "label_Alfa1";
            this.label_Alfa1.Size = new System.Drawing.Size(17, 18);
            this.label_Alfa1.TabIndex = 19;
            this.label_Alfa1.Text = "α";
            // 
            // label_Alfa2
            // 
            this.label_Alfa2.AutoSize = true;
            this.label_Alfa2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Alfa2.Location = new System.Drawing.Point(35, 217);
            this.label_Alfa2.Name = "label_Alfa2";
            this.label_Alfa2.Size = new System.Drawing.Size(17, 18);
            this.label_Alfa2.TabIndex = 20;
            this.label_Alfa2.Text = "α";
            // 
            // label_Alfa3
            // 
            this.label_Alfa3.AutoSize = true;
            this.label_Alfa3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Alfa3.Location = new System.Drawing.Point(37, 266);
            this.label_Alfa3.Name = "label_Alfa3";
            this.label_Alfa3.Size = new System.Drawing.Size(17, 18);
            this.label_Alfa3.TabIndex = 21;
            this.label_Alfa3.Text = "α";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(305, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "współczynnik destylacji";
            // 
            // label_Beta1
            // 
            this.label_Beta1.AutoSize = true;
            this.label_Beta1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Beta1.Location = new System.Drawing.Point(132, 139);
            this.label_Beta1.Name = "label_Beta1";
            this.label_Beta1.Size = new System.Drawing.Size(16, 18);
            this.label_Beta1.TabIndex = 24;
            this.label_Beta1.Text = "β";
            // 
            // label_Beta2
            // 
            this.label_Beta2.AutoSize = true;
            this.label_Beta2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Beta2.Location = new System.Drawing.Point(132, 217);
            this.label_Beta2.Name = "label_Beta2";
            this.label_Beta2.Size = new System.Drawing.Size(16, 18);
            this.label_Beta2.TabIndex = 25;
            this.label_Beta2.Text = "β";
            // 
            // label_Beta3
            // 
            this.label_Beta3.AutoSize = true;
            this.label_Beta3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Beta3.Location = new System.Drawing.Point(132, 266);
            this.label_Beta3.Name = "label_Beta3";
            this.label_Beta3.Size = new System.Drawing.Size(16, 18);
            this.label_Beta3.TabIndex = 26;
            this.label_Beta3.Text = "β";
            // 
            // listView_CriteriaToChose
            // 
            this.listView_CriteriaToChose.HideSelection = false;
            this.listView_CriteriaToChose.Location = new System.Drawing.Point(240, 102);
            this.listView_CriteriaToChose.Name = "listView_CriteriaToChose";
            this.listView_CriteriaToChose.Size = new System.Drawing.Size(50, 221);
            this.listView_CriteriaToChose.TabIndex = 27;
            this.listView_CriteriaToChose.UseCompatibleStateImageBehavior = false;
            this.listView_CriteriaToChose.ItemActivate += new System.EventHandler(this.ListView_CriteriaToChose_ItemActivate);
            // 
            // label_Alfa4
            // 
            this.label_Alfa4.AutoSize = true;
            this.label_Alfa4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Alfa4.Location = new System.Drawing.Point(328, 137);
            this.label_Alfa4.Name = "label_Alfa4";
            this.label_Alfa4.Size = new System.Drawing.Size(17, 18);
            this.label_Alfa4.TabIndex = 28;
            this.label_Alfa4.Text = "α";
            // 
            // label_Beta4
            // 
            this.label_Beta4.AutoSize = true;
            this.label_Beta4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Beta4.Location = new System.Drawing.Point(328, 182);
            this.label_Beta4.Name = "label_Beta4";
            this.label_Beta4.Size = new System.Drawing.Size(16, 18);
            this.label_Beta4.TabIndex = 29;
            this.label_Beta4.Text = "β";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label11.Location = new System.Drawing.Point(317, 218);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 15);
            this.label11.TabIndex = 30;
            this.label11.Text = "miejsc po przecinku";
            // 
            // textBox_DecimalPlaces
            // 
            this.textBox_DecimalPlaces.Location = new System.Drawing.Point(354, 249);
            this.textBox_DecimalPlaces.Multiline = true;
            this.textBox_DecimalPlaces.Name = "textBox_DecimalPlaces";
            this.textBox_DecimalPlaces.Size = new System.Drawing.Size(45, 25);
            this.textBox_DecimalPlaces.TabIndex = 31;
            this.textBox_DecimalPlaces.Leave += new System.EventHandler(this.TextBox_DecimalPlaces_FokusLeave);
            // 
            // panel_ChosingOptionsWithCheckBoxes
            // 
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.checkBox_TopDownDistillation);
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.checkBox_UpwardDistillation);
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.checkBox_Rankings);
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.checkBox_CompatibilityMatrix);
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.checkBox_NonComplianceSets);
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.checkBox_OutrankingSets);
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.checkBox_SetEqualityMatrix);
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.checkBox_RatingMatrix);
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.checkBox_CredibilityMatrix);
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.checkBox_ComplianceSet);
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.checkBox_CheckAllOptions);
            this.panel_ChosingOptionsWithCheckBoxes.Controls.Add(this.label_ChosingOptionsWithCheckBoxes);
            this.panel_ChosingOptionsWithCheckBoxes.Location = new System.Drawing.Point(474, 14);
            this.panel_ChosingOptionsWithCheckBoxes.Name = "panel_ChosingOptionsWithCheckBoxes";
            this.panel_ChosingOptionsWithCheckBoxes.Size = new System.Drawing.Size(240, 309);
            this.panel_ChosingOptionsWithCheckBoxes.TabIndex = 32;
            // 
            // checkBox_TopDownDistillation
            // 
            this.checkBox_TopDownDistillation.AutoSize = true;
            this.checkBox_TopDownDistillation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_TopDownDistillation.Location = new System.Drawing.Point(18, 236);
            this.checkBox_TopDownDistillation.Name = "checkBox_TopDownDistillation";
            this.checkBox_TopDownDistillation.Size = new System.Drawing.Size(124, 17);
            this.checkBox_TopDownDistillation.TabIndex = 47;
            this.checkBox_TopDownDistillation.Text = "destylacja zstepujaca";
            this.checkBox_TopDownDistillation.UseVisualStyleBackColor = true;
            this.checkBox_TopDownDistillation.Click += new System.EventHandler(this.CheckBox_TopDownDistillation_Click);
            // 
            // checkBox_UpwardDistillation
            // 
            this.checkBox_UpwardDistillation.AutoSize = true;
            this.checkBox_UpwardDistillation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_UpwardDistillation.Location = new System.Drawing.Point(18, 261);
            this.checkBox_UpwardDistillation.Name = "checkBox_UpwardDistillation";
            this.checkBox_UpwardDistillation.Size = new System.Drawing.Size(127, 17);
            this.checkBox_UpwardDistillation.TabIndex = 46;
            this.checkBox_UpwardDistillation.Text = "destylacja wstepujaca";
            this.checkBox_UpwardDistillation.UseVisualStyleBackColor = true;
            this.checkBox_UpwardDistillation.Click += new System.EventHandler(this.CheckBox_UpwardDistillation_Click);
            // 
            // checkBox_Rankings
            // 
            this.checkBox_Rankings.AutoSize = true;
            this.checkBox_Rankings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_Rankings.Location = new System.Drawing.Point(18, 287);
            this.checkBox_Rankings.Name = "checkBox_Rankings";
            this.checkBox_Rankings.Size = new System.Drawing.Size(60, 17);
            this.checkBox_Rankings.TabIndex = 45;
            this.checkBox_Rankings.Text = "rankingi";
            this.checkBox_Rankings.UseVisualStyleBackColor = true;
            this.checkBox_Rankings.Click += new System.EventHandler(this.CheckBox_Rankings_Click);
            // 
            // checkBox_CompatibilityMatrix
            // 
            this.checkBox_CompatibilityMatrix.AutoSize = true;
            this.checkBox_CompatibilityMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_CompatibilityMatrix.Location = new System.Drawing.Point(18, 81);
            this.checkBox_CompatibilityMatrix.Name = "checkBox_CompatibilityMatrix";
            this.checkBox_CompatibilityMatrix.Size = new System.Drawing.Size(110, 17);
            this.checkBox_CompatibilityMatrix.TabIndex = 42;
            this.checkBox_CompatibilityMatrix.Text = "macierz zgodnosci";
            this.checkBox_CompatibilityMatrix.UseVisualStyleBackColor = true;
            this.checkBox_CompatibilityMatrix.Click += new System.EventHandler(this.CheckBox_CompatibilityMatrix_Click);
            // 
            // checkBox_NonComplianceSets
            // 
            this.checkBox_NonComplianceSets.AutoSize = true;
            this.checkBox_NonComplianceSets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_NonComplianceSets.Location = new System.Drawing.Point(18, 107);
            this.checkBox_NonComplianceSets.Name = "checkBox_NonComplianceSets";
            this.checkBox_NonComplianceSets.Size = new System.Drawing.Size(115, 17);
            this.checkBox_NonComplianceSets.TabIndex = 41;
            this.checkBox_NonComplianceSets.Text = "zbiory niezgodnosci";
            this.checkBox_NonComplianceSets.UseVisualStyleBackColor = true;
            this.checkBox_NonComplianceSets.Click += new System.EventHandler(this.CheckBox_NonComplianceSets_Click);
            // 
            // checkBox_OutrankingSets
            // 
            this.checkBox_OutrankingSets.AutoSize = true;
            this.checkBox_OutrankingSets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_OutrankingSets.Location = new System.Drawing.Point(18, 132);
            this.checkBox_OutrankingSets.Name = "checkBox_OutrankingSets";
            this.checkBox_OutrankingSets.Size = new System.Drawing.Size(121, 17);
            this.checkBox_OutrankingSets.TabIndex = 40;
            this.checkBox_OutrankingSets.Text = "zbiory przewyzszania";
            this.checkBox_OutrankingSets.UseVisualStyleBackColor = true;
            this.checkBox_OutrankingSets.Click += new System.EventHandler(this.CheckBox_OutrankingSets_Click);
            // 
            // checkBox_SetEqualityMatrix
            // 
            this.checkBox_SetEqualityMatrix.AutoSize = true;
            this.checkBox_SetEqualityMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_SetEqualityMatrix.Location = new System.Drawing.Point(18, 158);
            this.checkBox_SetEqualityMatrix.Name = "checkBox_SetEqualityMatrix";
            this.checkBox_SetEqualityMatrix.Size = new System.Drawing.Size(166, 17);
            this.checkBox_SetEqualityMatrix.TabIndex = 39;
            this.checkBox_SetEqualityMatrix.Text = "macierz rownosci zbior. przew.";
            this.checkBox_SetEqualityMatrix.UseVisualStyleBackColor = true;
            this.checkBox_SetEqualityMatrix.Click += new System.EventHandler(this.CheckBox_SetEqualityMatrix_Click);
            // 
            // checkBox_RatingMatrix
            // 
            this.checkBox_RatingMatrix.AutoSize = true;
            this.checkBox_RatingMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_RatingMatrix.Location = new System.Drawing.Point(18, 210);
            this.checkBox_RatingMatrix.Name = "checkBox_RatingMatrix";
            this.checkBox_RatingMatrix.Size = new System.Drawing.Size(92, 17);
            this.checkBox_RatingMatrix.TabIndex = 38;
            this.checkBox_RatingMatrix.Text = "macierze ocen";
            this.checkBox_RatingMatrix.UseVisualStyleBackColor = true;
            this.checkBox_RatingMatrix.Click += new System.EventHandler(this.CheckBox_RatingMatrix_Click);
            // 
            // checkBox_CredibilityMatrix
            // 
            this.checkBox_CredibilityMatrix.AutoSize = true;
            this.checkBox_CredibilityMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_CredibilityMatrix.Location = new System.Drawing.Point(18, 184);
            this.checkBox_CredibilityMatrix.Name = "checkBox_CredibilityMatrix";
            this.checkBox_CredibilityMatrix.Size = new System.Drawing.Size(129, 17);
            this.checkBox_CredibilityMatrix.TabIndex = 37;
            this.checkBox_CredibilityMatrix.Text = "macierz wiarygodnosci";
            this.checkBox_CredibilityMatrix.UseVisualStyleBackColor = true;
            this.checkBox_CredibilityMatrix.Click += new System.EventHandler(this.CheckBox_CredibilityMatrix_Click);
            // 
            // checkBox_ComplianceSet
            // 
            this.checkBox_ComplianceSet.AutoSize = true;
            this.checkBox_ComplianceSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_ComplianceSet.Location = new System.Drawing.Point(18, 55);
            this.checkBox_ComplianceSet.Name = "checkBox_ComplianceSet";
            this.checkBox_ComplianceSet.Size = new System.Drawing.Size(101, 17);
            this.checkBox_ComplianceSet.TabIndex = 36;
            this.checkBox_ComplianceSet.Text = "zbiory zgodnosci";
            this.checkBox_ComplianceSet.UseVisualStyleBackColor = true;
            this.checkBox_ComplianceSet.Click += new System.EventHandler(this.CheckBox_ComplianceSet_Click);
            // 
            // checkBox_CheckAllOptions
            // 
            this.checkBox_CheckAllOptions.AutoSize = true;
            this.checkBox_CheckAllOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_CheckAllOptions.Location = new System.Drawing.Point(18, 29);
            this.checkBox_CheckAllOptions.Name = "checkBox_CheckAllOptions";
            this.checkBox_CheckAllOptions.Size = new System.Drawing.Size(108, 17);
            this.checkBox_CheckAllOptions.TabIndex = 35;
            this.checkBox_CheckAllOptions.Text = "zaznacz wszystko";
            this.checkBox_CheckAllOptions.UseVisualStyleBackColor = true;
            this.checkBox_CheckAllOptions.Click += new System.EventHandler(this.CheckBox_CheckAllOptions_Click);
            // 
            // label_ChosingOptionsWithCheckBoxes
            // 
            this.label_ChosingOptionsWithCheckBoxes.AutoSize = true;
            this.label_ChosingOptionsWithCheckBoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_ChosingOptionsWithCheckBoxes.Location = new System.Drawing.Point(5, 5);
            this.label_ChosingOptionsWithCheckBoxes.Name = "label_ChosingOptionsWithCheckBoxes";
            this.label_ChosingOptionsWithCheckBoxes.Size = new System.Drawing.Size(230, 15);
            this.label_ChosingOptionsWithCheckBoxes.TabIndex = 24;
            this.label_ChosingOptionsWithCheckBoxes.Text = "wybierz dane do wyświetlenia i zapisania";
            // 
            // checkBox_TurnOffVeto
            // 
            this.checkBox_TurnOffVeto.AutoSize = true;
            this.checkBox_TurnOffVeto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_TurnOffVeto.Location = new System.Drawing.Point(38, 306);
            this.checkBox_TurnOffVeto.Name = "checkBox_TurnOffVeto";
            this.checkBox_TurnOffVeto.Size = new System.Drawing.Size(184, 17);
            this.checkBox_TurnOffVeto.TabIndex = 33;
            this.checkBox_TurnOffVeto.Text = "wyłącz weto dla danego kryterium";
            this.checkBox_TurnOffVeto.UseVisualStyleBackColor = true;
            this.checkBox_TurnOffVeto.Click += new System.EventHandler(this.CheckBox_TurnOffVeto_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(35, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 15);
            this.label4.TabIndex = 34;
            this.label4.Text = "współczynniki progu preferencji";
            // 
            // tabControl_LeaderBoards
            // 
            this.tabControl_LeaderBoards.Location = new System.Drawing.Point(23, 343);
            this.tabControl_LeaderBoards.Name = "tabControl_LeaderBoards";
            this.tabControl_LeaderBoards.SelectedIndex = 0;
            this.tabControl_LeaderBoards.Size = new System.Drawing.Size(691, 352);
            this.tabControl_LeaderBoards.TabIndex = 36;
            // 
            // groupBox_ForPanelWithImg
            // 
            this.groupBox_ForPanelWithImg.Controls.Add(this.panel_WithScrllOptAndImg);
            this.groupBox_ForPanelWithImg.Location = new System.Drawing.Point(730, 343);
            this.groupBox_ForPanelWithImg.Name = "groupBox_ForPanelWithImg";
            this.groupBox_ForPanelWithImg.Size = new System.Drawing.Size(501, 352);
            this.groupBox_ForPanelWithImg.TabIndex = 37;
            this.groupBox_ForPanelWithImg.TabStop = false;
            this.groupBox_ForPanelWithImg.Text = "Wykorzystane wzory";
            // 
            // panel_WithScrllOptAndImg
            // 
            this.panel_WithScrllOptAndImg.Location = new System.Drawing.Point(6, 19);
            this.panel_WithScrllOptAndImg.Name = "panel_WithScrllOptAndImg";
            this.panel_WithScrllOptAndImg.Size = new System.Drawing.Size(489, 327);
            this.panel_WithScrllOptAndImg.TabIndex = 0;
            // 
            // tableLayoutPanel_BasicMatrix
            // 
            this.tableLayoutPanel_BasicMatrix.ColumnCount = 1;
            this.tableLayoutPanel_BasicMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_BasicMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_BasicMatrix.Location = new System.Drawing.Point(730, 16);
            this.tableLayoutPanel_BasicMatrix.Name = "tableLayoutPanel_BasicMatrix";
            this.tableLayoutPanel_BasicMatrix.RowCount = 1;
            this.tableLayoutPanel_BasicMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_BasicMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 307F));
            this.tableLayoutPanel_BasicMatrix.Size = new System.Drawing.Size(501, 307);
            this.tableLayoutPanel_BasicMatrix.TabIndex = 38;
            // 
            // UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel_BasicMatrix);
            this.Controls.Add(this.groupBox_ForPanelWithImg);
            this.Controls.Add(this.tabControl_LeaderBoards);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_TurnOffVeto);
            this.Controls.Add(this.panel_ChosingOptionsWithCheckBoxes);
            this.Controls.Add(this.textBox_DecimalPlaces);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label_Beta4);
            this.Controls.Add(this.label_Alfa4);
            this.Controls.Add(this.listView_CriteriaToChose);
            this.Controls.Add(this.label_Beta3);
            this.Controls.Add(this.label_Beta2);
            this.Controls.Add(this.label_Beta1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_Alfa3);
            this.Controls.Add(this.label_Alfa2);
            this.Controls.Add(this.label_Alfa1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_Criteria);
            this.Controls.Add(this.label_Alternatives);
            this.Controls.Add(this.textBox_Criteria);
            this.Controls.Add(this.textBox_Alfa1);
            this.Controls.Add(this.textBox_Alfa2);
            this.Controls.Add(this.textBox_Alfa3);
            this.Controls.Add(this.textBox_Beta1);
            this.Controls.Add(this.textBox_Beta2);
            this.Controls.Add(this.textBox_Beta3);
            this.Controls.Add(this.textBox_Alfa4);
            this.Controls.Add(this.textBox_Beta4);
            this.Controls.Add(this.textBox_Alternatives);
            this.Controls.Add(this.button_SaveData);
            this.Controls.Add(this.button_SaveTab);
            this.Controls.Add(this.button_Calculate);
            this.Controls.Add(this.button_ReadTab);
            this.Controls.Add(this.button_CreateTab);
            this.Name = "UserControl";
            this.Size = new System.Drawing.Size(1242, 720);
            this.Load += new System.EventHandler(this.UserControl_Load);
            this.panel_ChosingOptionsWithCheckBoxes.ResumeLayout(false);
            this.panel_ChosingOptionsWithCheckBoxes.PerformLayout();
            this.groupBox_ForPanelWithImg.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_CreateTab;
        private Button button_ReadTab;
        private Button button_Calculate;
        private Button button_SaveTab;
        private Button button_SaveData;
        private TextBox textBox_Alternatives;
        private TextBox textBox_Beta4;
        private TextBox textBox_Alfa4;
        private TextBox textBox_Beta3;
        private TextBox textBox_Beta2;
        private TextBox textBox_Beta1;
        private TextBox textBox_Alfa3;
        private TextBox textBox_Alfa2;
        private TextBox textBox_Alfa1;
        private Label label_Alternatives;
        private Label label3;
        private Label label_Alfa1;
        private Label label_Alfa2;
        private Label label_Alfa3;
        private Label label7;
        private Label label_Beta1;
        private Label label_Beta2;
        private Label label_Beta3;
        private ListView listView_CriteriaToChose;
        private Label label_Alfa4;
        private Label label_Beta4;
        private Label label11;
        private TextBox textBox_DecimalPlaces;
        private Panel panel_ChosingOptionsWithCheckBoxes;
        private Label label_ChosingOptionsWithCheckBoxes;
        private CheckBox checkBox_TurnOffVeto;
        private Label label4;
        private CheckBox checkBox_CompatibilityMatrix;
        private CheckBox checkBox_NonComplianceSets;
        private CheckBox checkBox_OutrankingSets;
        private CheckBox checkBox_SetEqualityMatrix;
        private CheckBox checkBox_RatingMatrix;
        private CheckBox checkBox_CredibilityMatrix;
        private CheckBox checkBox_ComplianceSet;
        private CheckBox checkBox_CheckAllOptions;
        private CheckBox checkBox_TopDownDistillation;
        private CheckBox checkBox_UpwardDistillation;
        private CheckBox checkBox_Rankings;
        private TabControl tabControl_LeaderBoards;
        private GroupBox groupBox_ForPanelWithImg;
        private Panel panel_WithScrllOptAndImg;
        private Label label_Criteria;
        private TextBox textBox_Criteria;
        private TableLayoutPanel tableLayoutPanel_BasicMatrix;
    }
}