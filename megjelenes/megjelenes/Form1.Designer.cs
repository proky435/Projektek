
namespace megjelenes
{
    partial class Megjelenés
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
            this.stilus = new System.Windows.Forms.ListBox();
            this.háttér = new System.Windows.Forms.ListBox();
            this.méret = new System.Windows.Forms.ListBox();
            this.szín = new System.Windows.Forms.ListBox();
            this.label1Minta = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBox1Bold = new System.Windows.Forms.CheckBox();
            this.checkBox2Italic = new System.Windows.Forms.CheckBox();
            this.checkBox3UnderLine = new System.Windows.Forms.CheckBox();
            this.radioButton1Black = new System.Windows.Forms.RadioButton();
            this.radioButton2Gray = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1SzinBlack = new System.Windows.Forms.RadioButton();
            this.radioButton2szinRed = new System.Windows.Forms.RadioButton();
            this.numericUpDown1Meret = new System.Windows.Forms.NumericUpDown();
            this.button1Kilepes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1Meret)).BeginInit();
            this.SuspendLayout();
            // 
            // stilus
            // 
            this.stilus.FormattingEnabled = true;
            this.stilus.Location = new System.Drawing.Point(12, 37);
            this.stilus.Name = "stilus";
            this.stilus.Size = new System.Drawing.Size(241, 95);
            this.stilus.TabIndex = 0;
            // 
            // háttér
            // 
            this.háttér.FormattingEnabled = true;
            this.háttér.Location = new System.Drawing.Point(12, 145);
            this.háttér.Name = "háttér";
            this.háttér.Size = new System.Drawing.Size(241, 69);
            this.háttér.TabIndex = 1;
            // 
            // méret
            // 
            this.méret.FormattingEnabled = true;
            this.méret.Location = new System.Drawing.Point(12, 220);
            this.méret.Name = "méret";
            this.méret.Size = new System.Drawing.Size(241, 69);
            this.méret.TabIndex = 2;
            // 
            // szín
            // 
            this.szín.FormattingEnabled = true;
            this.szín.Location = new System.Drawing.Point(12, 295);
            this.szín.Name = "szín";
            this.szín.Size = new System.Drawing.Size(241, 69);
            this.szín.TabIndex = 3;
            // 
            // label1Minta
            // 
            this.label1Minta.AutoSize = true;
            this.label1Minta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1Minta.Location = new System.Drawing.Point(92, 391);
            this.label1Minta.Name = "label1Minta";
            this.label1Minta.Size = new System.Drawing.Size(80, 31);
            this.label1Minta.TabIndex = 4;
            this.label1Minta.Text = "Minta";
            this.label1Minta.Click += new System.EventHandler(this.label1Minta_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(198, 36);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(55, 29);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // checkBox1Bold
            // 
            this.checkBox1Bold.AutoSize = true;
            this.checkBox1Bold.Location = new System.Drawing.Point(21, 58);
            this.checkBox1Bold.Name = "checkBox1Bold";
            this.checkBox1Bold.Size = new System.Drawing.Size(46, 17);
            this.checkBox1Bold.TabIndex = 6;
            this.checkBox1Bold.Text = "bold";
            this.checkBox1Bold.UseVisualStyleBackColor = true;
            this.checkBox1Bold.CheckedChanged += new System.EventHandler(this.checkBox1Bold_CheckedChanged);
            // 
            // checkBox2Italic
            // 
            this.checkBox2Italic.AutoSize = true;
            this.checkBox2Italic.Location = new System.Drawing.Point(21, 81);
            this.checkBox2Italic.Name = "checkBox2Italic";
            this.checkBox2Italic.Size = new System.Drawing.Size(47, 17);
            this.checkBox2Italic.TabIndex = 7;
            this.checkBox2Italic.Text = "italic";
            this.checkBox2Italic.UseVisualStyleBackColor = true;
            this.checkBox2Italic.CheckedChanged += new System.EventHandler(this.checkBox2Italic_CheckedChanged);
            // 
            // checkBox3UnderLine
            // 
            this.checkBox3UnderLine.AutoSize = true;
            this.checkBox3UnderLine.Location = new System.Drawing.Point(21, 104);
            this.checkBox3UnderLine.Name = "checkBox3UnderLine";
            this.checkBox3UnderLine.Size = new System.Drawing.Size(73, 17);
            this.checkBox3UnderLine.TabIndex = 8;
            this.checkBox3UnderLine.Text = "underLine";
            this.checkBox3UnderLine.UseVisualStyleBackColor = true;
            this.checkBox3UnderLine.CheckedChanged += new System.EventHandler(this.checkBox3UnderLine_CheckedChanged);
            // 
            // radioButton1Black
            // 
            this.radioButton1Black.AutoSize = true;
            this.radioButton1Black.Checked = true;
            this.radioButton1Black.Location = new System.Drawing.Point(21, 168);
            this.radioButton1Black.Name = "radioButton1Black";
            this.radioButton1Black.Size = new System.Drawing.Size(56, 17);
            this.radioButton1Black.TabIndex = 9;
            this.radioButton1Black.TabStop = true;
            this.radioButton1Black.Text = "Yellow";
            this.radioButton1Black.UseVisualStyleBackColor = true;
            this.radioButton1Black.CheckedChanged += new System.EventHandler(this.radioButton1Black_CheckedChanged);
            // 
            // radioButton2Gray
            // 
            this.radioButton2Gray.AutoSize = true;
            this.radioButton2Gray.Location = new System.Drawing.Point(140, 168);
            this.radioButton2Gray.Name = "radioButton2Gray";
            this.radioButton2Gray.Size = new System.Drawing.Size(47, 17);
            this.radioButton2Gray.TabIndex = 10;
            this.radioButton2Gray.Text = "Gray";
            this.radioButton2Gray.UseVisualStyleBackColor = true;
            this.radioButton2Gray.CheckedChanged += new System.EventHandler(this.radioButton2Gray_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(100, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "px";
            // 
            // radioButton1SzinBlack
            // 
            this.radioButton1SzinBlack.AutoSize = true;
            this.radioButton1SzinBlack.Location = new System.Drawing.Point(27, 318);
            this.radioButton1SzinBlack.Name = "radioButton1SzinBlack";
            this.radioButton1SzinBlack.Size = new System.Drawing.Size(52, 17);
            this.radioButton1SzinBlack.TabIndex = 13;
            this.radioButton1SzinBlack.Text = "Black";
            this.radioButton1SzinBlack.UseVisualStyleBackColor = true;
            this.radioButton1SzinBlack.CheckedChanged += new System.EventHandler(this.radioButton1SzinBlack_CheckedChanged);
            // 
            // radioButton2szinRed
            // 
            this.radioButton2szinRed.AutoSize = true;
            this.radioButton2szinRed.Location = new System.Drawing.Point(140, 318);
            this.radioButton2szinRed.Name = "radioButton2szinRed";
            this.radioButton2szinRed.Size = new System.Drawing.Size(45, 17);
            this.radioButton2szinRed.TabIndex = 14;
            this.radioButton2szinRed.Text = "Red";
            this.radioButton2szinRed.UseVisualStyleBackColor = true;
            this.radioButton2szinRed.CheckedChanged += new System.EventHandler(this.radioButton2szinRed_CheckedChanged);
            // 
            // numericUpDown1Meret
            // 
            this.numericUpDown1Meret.Location = new System.Drawing.Point(27, 245);
            this.numericUpDown1Meret.Name = "numericUpDown1Meret";
            this.numericUpDown1Meret.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown1Meret.TabIndex = 15;
            this.numericUpDown1Meret.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1Meret.ValueChanged += new System.EventHandler(this.numericUpDown1Meret_ValueChanged);
            // 
            // button1Kilepes
            // 
            this.button1Kilepes.Location = new System.Drawing.Point(198, 104);
            this.button1Kilepes.Name = "button1Kilepes";
            this.button1Kilepes.Size = new System.Drawing.Size(55, 23);
            this.button1Kilepes.TabIndex = 16;
            this.button1Kilepes.Text = "Kilépés";
            this.button1Kilepes.UseVisualStyleBackColor = true;
            this.button1Kilepes.Click += new System.EventHandler(this.button1Kilepes_Click);
            // 
            // Megjelenés
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 450);
            this.Controls.Add(this.button1Kilepes);
            this.Controls.Add(this.numericUpDown1Meret);
            this.Controls.Add(this.radioButton2szinRed);
            this.Controls.Add(this.radioButton1SzinBlack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton2Gray);
            this.Controls.Add(this.radioButton1Black);
            this.Controls.Add(this.checkBox3UnderLine);
            this.Controls.Add(this.checkBox2Italic);
            this.Controls.Add(this.checkBox1Bold);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label1Minta);
            this.Controls.Add(this.szín);
            this.Controls.Add(this.méret);
            this.Controls.Add(this.háttér);
            this.Controls.Add(this.stilus);
            this.Name = "Megjelenés";
            this.Text = "Megjelenés";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1Meret)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox stilus;
        private System.Windows.Forms.ListBox háttér;
        private System.Windows.Forms.ListBox méret;
        private System.Windows.Forms.ListBox szín;
        private System.Windows.Forms.Label label1Minta;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBox1Bold;
        private System.Windows.Forms.CheckBox checkBox2Italic;
        private System.Windows.Forms.CheckBox checkBox3UnderLine;
        private System.Windows.Forms.RadioButton radioButton1Black;
        private System.Windows.Forms.RadioButton radioButton2Gray;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1SzinBlack;
        private System.Windows.Forms.RadioButton radioButton2szinRed;
        private System.Windows.Forms.NumericUpDown numericUpDown1Meret;
        private System.Windows.Forms.Button button1Kilepes;
    }
}

