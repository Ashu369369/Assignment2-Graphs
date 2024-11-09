namespace Assignment2_Graphs
{
    partial class Form1
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
            this.inputData = new System.Windows.Forms.TextBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.pieChartControl = new Assignment2_Graphs.PieChartControl();
            this.SuspendLayout();
            // 
            // inputData
            // 
            this.inputData.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.inputData.Location = new System.Drawing.Point(30, 30);
            this.inputData.Name = "inputData";
            this.inputData.Size = new System.Drawing.Size(300, 33);
            this.inputData.TabIndex = 0;
            // 
            // drawButton
            // 
            this.drawButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.drawButton.ForeColor = System.Drawing.Color.White;
            this.drawButton.Location = new System.Drawing.Point(350, 30);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(120, 35);
            this.drawButton.TabIndex = 1;
            this.drawButton.Text = "Draw Graph";
            this.drawButton.UseVisualStyleBackColor = false;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // pieChartControl
            // 
            this.pieChartControl.Location = new System.Drawing.Point(30, 80);
            this.pieChartControl.Name = "pieChartControl";
            this.pieChartControl.Size = new System.Drawing.Size(600, 300);
            this.pieChartControl.TabIndex = 2;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pieChartControl);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.inputData);
            this.Name = "Form1";
            this.Text = "Pie Chart Application";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox inputData;
        private System.Windows.Forms.Button drawButton;
        private PieChartControl pieChartControl;
    }
}
