
namespace MicroSimulations
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
            this.closingYearLabel = new System.Windows.Forms.Label();
            this.closingYearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.resultsBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.closingYearNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // closingYearLabel
            // 
            this.closingYearLabel.AutoSize = true;
            this.closingYearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.closingYearLabel.Location = new System.Drawing.Point(29, 15);
            this.closingYearLabel.Name = "closingYearLabel";
            this.closingYearLabel.Size = new System.Drawing.Size(47, 13);
            this.closingYearLabel.TabIndex = 0;
            this.closingYearLabel.Text = "Záróév";
            // 
            // closingYearNumericUpDown
            // 
            this.closingYearNumericUpDown.Location = new System.Drawing.Point(76, 13);
            this.closingYearNumericUpDown.Maximum = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            this.closingYearNumericUpDown.Name = "closingYearNumericUpDown";
            this.closingYearNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.closingYearNumericUpDown.TabIndex = 1;
            this.closingYearNumericUpDown.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fileNameLabel.Location = new System.Drawing.Point(156, 18);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(84, 13);
            this.fileNameLabel.TabIndex = 2;
            this.fileNameLabel.Text = "Népesség fájl";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(246, 15);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(288, 20);
            this.fileNameTextBox.TabIndex = 3;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(540, 15);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(119, 23);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(665, 15);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(123, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // resultsBox
            // 
            this.resultsBox.Location = new System.Drawing.Point(32, 47);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(756, 380);
            this.resultsBox.TabIndex = 6;
            this.resultsBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resultsBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.closingYearNumericUpDown);
            this.Controls.Add(this.closingYearLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.closingYearNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label closingYearLabel;
        private System.Windows.Forms.NumericUpDown closingYearNumericUpDown;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RichTextBox resultsBox;
    }
}

