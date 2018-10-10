using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.richTextBox1.Text.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
                MessageBox.Show("Буфер содержит изображение или буфер пуст", "Внимание!", MessageBoxButtons.OK);
            else
                this.richTextBox2.AppendText(Clipboard.GetText());
        }

        public Bitmap ImageFromScreen()
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Size size = bmp.Size;
            size.Width = 462;
            size.Height = 222;
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y,
                    0, 0, Screen.PrimaryScreen.Bounds.Size);

            }
            return bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(ImageFromScreen());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
                MessageBox.Show("Буфер содержит текст или буфер пуст", "Внимание!", MessageBoxButtons.OK);
            else
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox1.Image = Clipboard.GetImage();
            }

        }
    }
}
