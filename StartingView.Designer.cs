namespace ElectreAp
{
    partial class StartingView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Next = new System.Windows.Forms.Button();
            this.comboBox_ChoseAlgorithm = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_Next
            // 
            this.button_Next.Location = new System.Drawing.Point(416, 277);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(85, 30);
            this.button_Next.TabIndex = 1;
            this.button_Next.Text = "Next";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.Button_Next_Click);
            // 
            // comboBox_ChoseAlgorithm
            // 
            this.comboBox_ChoseAlgorithm.FormattingEnabled = true;
            this.comboBox_ChoseAlgorithm.Location = new System.Drawing.Point(230, 283);
            this.comboBox_ChoseAlgorithm.Name = "comboBox_ChoseAlgorithm";
            this.comboBox_ChoseAlgorithm.Size = new System.Drawing.Size(158, 21);
            this.comboBox_ChoseAlgorithm.TabIndex = 2;
            // 
            // StartingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox_ChoseAlgorithm);
            this.Controls.Add(this.button_Next);
            this.Name = "StartingView";
            this.Text = "StartingView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.ComboBox comboBox_ChoseAlgorithm;
    }
}