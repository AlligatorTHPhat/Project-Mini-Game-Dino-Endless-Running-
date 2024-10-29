using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Game_Dino_Endless_Running
{
    public partial class Form1 : Form
    {
        PrivateFontCollection newFont = new PrivateFontCollection();

        Image backgroundImage;

        int backgroundWidth;
        int backgroundHeight;

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;

            newFont.AddFontFile("Font/pixel.ttf");

            initChooseModeButton();
        }
        private void initChooseModeButton()
        {
            backgroundWidth = 1200;
            backgroundHeight = 600;

            backgroundImage = Properties.Resources.BGPixel0;

            btnEasy.BackColor = Color.LightGray;
            btnEasy.ForeColor = Color.Blue;
            btnEasy.Font = new Font(newFont.Families[0], 14, FontStyle.Bold);

            btnEasy.Click += (s, e) =>
            {
                Form2 trexForm = new Form2(10); 
                trexForm.Show();
                this.Hide();
            };


            btnNormal.BackColor = Color.LightGray;
            btnNormal.ForeColor = Color.DarkGreen;
            btnNormal.Font = new Font(newFont.Families[0], 14, FontStyle.Bold);

            btnNormal.Click += (s, e) =>
            {
                Form2 trexForm = new Form2(15); 
                trexForm.Show();
                this.Hide();
            };

            btnHard.BackColor = Color.LightGray;
            btnHard.ForeColor = Color.Red;
            btnHard.Font = new Font(newFont.Families[0], 14, FontStyle.Bold);

            btnHard.Click += (s, e) =>
            {
                Form2 trexForm = new Form2(20); 
                trexForm.Show();
                this.Hide();
            };

            btnExit.BackColor = Color.LightGray;
            btnExit.ForeColor = Color.Black;
            btnExit.Font = new Font(newFont.Families[0], 14, FontStyle.Bold);

            this.Controls.Add(btnEasy);
            this.Controls.Add(btnNormal);
            this.Controls.Add(btnHard);
            this.Controls.Add(btnExit);

        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;

            Canvas.DrawImage(backgroundImage, 0, 0, backgroundWidth, backgroundHeight);

            Canvas.SmoothingMode = SmoothingMode.AntiAlias;
            Canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnHard_Click(object sender, EventArgs e)
        {

        }
    }
}
