using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace megjelenes
{
    public partial class Megjelenés : Form
    {
        public Megjelenés()
        {
            InitializeComponent();
            numericUpDown1Meret.Minimum = 1;
            numericUpDown1Meret.Maximum = 16;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void button1Kilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1Minta_Click(object sender, EventArgs e)
        {
            checkBox1Bold.Checked = label1Minta.Font.Bold;
            checkBox2Italic.Checked = label1Minta.Font.Italic;
            checkBox3UnderLine.Checked = label1Minta.Font.Underline;

            if (radioButton1SzinBlack.Checked) label1Minta.ForeColor.Equals(Color.Black);
            if (radioButton2szinRed.Checked) label1Minta.ForeColor.Equals(Color.Red);

        }

        private void radioButton1SzinBlack_CheckedChanged(object sender, EventArgs e)
        {
            label1Minta.ForeColor = Color.Black;
        }

        private void radioButton2szinRed_CheckedChanged(object sender, EventArgs e)
        {
            label1Minta.ForeColor = Color.Red;
        }

        private void radioButton1Black_CheckedChanged(object sender, EventArgs e)
        {
            label1Minta.BackColor = Color.Yellow;
        }

        private void radioButton2Gray_CheckedChanged(object sender, EventArgs e)
        {
            label1Minta.BackColor = Color.Gray;
        }

        private void checkBox1Bold_CheckedChanged(object sender, EventArgs e)
        {
            /*Font alap = this.label1Minta.Font;
            if (checkBox1Bold.Checked) this.label1Minta.Font = new Font(alap, alap.Style | FontStyle.Bold);
            else this.label1Minta.Font = new Font(alap, alap.Style & ~FontStyle.Bold);*/
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
           if (checkBox1Bold.Checked == true && checkBox2Italic.Checked == true && checkBox3UnderLine.Checked == true)
            {
                label1Minta.Font = new Font(label1Minta.Font, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            }
            else if(checkBox1Bold.Checked==true && checkBox2Italic.Checked==true)
            {
                label1Minta.Font = new Font(label1Minta.Font, FontStyle.Bold | FontStyle.Italic);
            }
            else if(checkBox1Bold.Checked == true && checkBox3UnderLine.Checked == true)
            {
                label1Minta.Font = new Font(label1Minta.Font, FontStyle.Bold | FontStyle.Underline);
            }
            else if(checkBox2Italic.Checked == true && checkBox3UnderLine.Checked == true)
            {
                label1Minta.Font = new Font(label1Minta.Font, FontStyle.Italic | FontStyle.Underline);
            }
            else if(checkBox1Bold.Checked==true)
            {
                label1Minta.Font = new Font(label1Minta.Font, FontStyle.Bold);
            }
            else if (checkBox2Italic.Checked == true)
            {
                label1Minta.Font = new Font(label1Minta.Font, FontStyle.Italic);
            }
            else if (checkBox3UnderLine.Checked == true)
            {
                label1Minta.Font = new Font(label1Minta.Font, FontStyle.Underline);
            }
            else if (checkBox1Bold.Checked == false && checkBox2Italic.Checked == false && checkBox3UnderLine.Checked==false)
            {
                label1Minta.Font = new Font(label1Minta.Font, FontStyle.Regular);
            }          
        }

        private void numericUpDown1Meret_ValueChanged(object sender, EventArgs e)
        {
            label1Minta.Size = new System.Drawing.Size();
        }

        private void checkBox2Italic_CheckedChanged(object sender, EventArgs e)
        {
           /* Font alap = this.label1Minta.Font;
            if (checkBox1Bold.Checked) this.label1Minta.Font = new Font(alap, alap.Style | FontStyle.Italic);
            else this.label1Minta.Font = new Font(alap, alap.Style & ~FontStyle.Italic);*/
        }

        private void checkBox3UnderLine_CheckedChanged(object sender, EventArgs e)
        {
          /*  Font alap = this.label1Minta.Font;
            if (checkBox1Bold.Checked) this.label1Minta.Font = new Font(alap, alap.Style | FontStyle.Underline);
            else this.label1Minta.Font = new Font(alap, alap.Style & ~FontStyle.Underline);*/
        }
    }
}
