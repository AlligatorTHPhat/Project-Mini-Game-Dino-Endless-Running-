using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace Project_Game_Dino_Endless_Running
{
    public partial class Form2 : Form
    {
        Image backgroundImage;
        Image backgroundImage2;
        int backgroundState = 1;

        int backgroundWidth;
        int backgroundHeight;

        int bgPositionX = 0;
        int bgPositionY = 0;
        int bg2PositionX = 0;
        int defaultPosition = 470;

        int formWidth;
        int attackTimer = 0;
        int attackR = 0;
        int score = 0;
        int speed = 10;

        int[] flyingPosition = { 470, 440, 470, 440 };

        bool jumping = false;
        bool changeAnim = false;
        bool flyingAttack = false;
        bool gameover = false;

        Random random = new Random();

        List<PictureBox> obstacles = new List<PictureBox>();
        PictureBox hitBox = new PictureBox();

        PrivateFontCollection newFont = new PrivateFontCollection();

        SoundPlayer HitSound;
        SoundPlayer jumpSound;

        Button Restart;
        Button Exit;

        int obstaclesSpeed;
        int HighestScore = 0;
        string scoreFilePath = "highest_score.txt";

        String localPath = Application.StartupPath;
        public Form2(int obsSpeed)
        {
            InitializeComponent();

            this.KeyPreview = true;

            newFont.AddFontFile("Font/pixel.ttf");

            LoadHighestScore();

            this.obstaclesSpeed = obsSpeed; 

            GameSetUp();

            Reset();

            InitStartExit();
        }

        private void LoadHighestScore()
        {
            if (File.Exists(scoreFilePath))
            {
                int.TryParse(File.ReadAllText(scoreFilePath), out HighestScore);
                lblHighestScore.Text = "Highest Score: " + HighestScore;
                int.TryParse(File.ReadAllText(scoreFilePath), out HighestScore);
                lblHighestScore.Text = "Highest Score: " + HighestScore;           
            }

        }

        private void GameSetUp()
        {
            backgroundWidth = 1200;
            backgroundHeight = 600;
            bg2PositionX = 1200;

            if(obstaclesSpeed < 20)
            {
                backgroundImage = Properties.Resources.BGPixel1;
                backgroundImage2 = Properties.Resources.BGPixel1;
            }

            else
            {
                backgroundImage = Properties.Resources.BGPixel3;
                backgroundImage2 = Properties.Resources.BGPixel3;
            }
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            formWidth = this.ClientSize.Width;
            this.BackColor = Color.Black;
            obstacles.Add(obstacles1);
            obstacles.Add(obstacles2);
            obstacles.Add(obstacles3);

            obstacles1.Top = defaultPosition;  
            obstacles2.Top = defaultPosition;
            obstacles3.Top = flyingPosition[random.Next(flyingPosition.Length)];

            lblScore.Font = new Font(newFont.Families[0], 14, FontStyle.Bold);
            lblScore.ForeColor = Color.White;
            lblScore.BackColor = Color.Transparent;

            lblHighestScore.Font = new Font(newFont.Families[0], 14, FontStyle.Bold);
            lblHighestScore.ForeColor = Color.White;
            lblHighestScore.BackColor = Color.Transparent;

            hitBox.BackColor = Color.Transparent;
            hitBox.Width = Character.Width / 3;
            hitBox.Height = Character.Height - 20;

            this.Controls.Add(hitBox);
            gameover = false;

            attackR = random.Next(12, 20);
        }
        private void Reset()
        {
            Character.Image = Properties.Resources.Running;
            Character.Top = defaultPosition;

            obstacles1.Left = formWidth + random.Next(100, 200);
            obstacles2.Left = obstacles1.Left + random.Next(400, 800);
            obstacles3.Left = obstacles1.Left + random.Next(400, 600);

            obstacles1.Top = defaultPosition + 40;
            obstacles2.Top = defaultPosition;
            obstacles3.Top = defaultPosition;
             
            GameTimer.Start();
            score = 0;
            attackTimer = 0;
            speed = 10;

            gameover = false;
            changeAnim = false;
            jumping = false;

        }

        private void InitStartExit()
        {
            Restart = new Button();
            Restart.Text = "Restart";
            Restart.Size = new Size(120, 60);
            Restart.Location = new Point(this.ClientSize.Width / 2 - 50, this.ClientSize.Height / 2 - 70);
            Restart.Visible = false;
            Restart.Click += btnRestart_Click;
            Restart.BackColor = Color.LightGray;
            Restart.ForeColor = Color.Black;
            Restart.Font = new Font(newFont.Families[0], 11, FontStyle.Bold);

            Exit = new Button();
            Exit.Text = "Exit";
            Exit.Size = new Size(120, 60);
            Exit.Location = new Point(this.ClientSize.Width / 2 - 50, this.ClientSize.Height / 2);
            Exit.Visible = false;
            Exit.Click += btnExit_Click;
            Exit.BackColor = Color.LightGray;
            Exit.ForeColor = Color.Black;
            Exit.Font = new Font(newFont.Families[0], 11, FontStyle.Bold);

            this.Controls.Add(Restart);
            this.Controls.Add(Exit);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (!gameover)
            {
                if (e.KeyCode == Keys.Up && !jumping)
                {
                    jumping = true;
                    jumpSound = new SoundPlayer(localPath + @"/Audio/Jump.wav");
                    jumpSound.Play();
                }
                if (e.KeyCode == Keys.Down && !jumping)
                {
                    if (changeAnim == false)
                    {
                        Character.Image = Properties.Resources.Running;
                        changeAnim = true;
                    }
                    Character.Top = defaultPosition + 30;
                }
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && !gameover)
            {
                Character.Image = Properties.Resources.Running;
                Character.Top = defaultPosition;
                changeAnim = false;
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            Canvas.DrawImage(backgroundImage, bgPositionX, bgPositionY, backgroundWidth, backgroundHeight);
            Canvas.DrawImage(backgroundImage2, bg2PositionX, bgPositionY, backgroundWidth, backgroundHeight);

            Canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            MoveBackGrounds();
            MoveObstacles();

            this.Invalidate();

            lblScore.Text = "Score: " + score;

            if (score > 30)
                lblScore.ForeColor = Color.Red;
            else if (score > 20)
                lblScore.ForeColor = Color.Yellow;
            else if (score > 10)
                lblScore.ForeColor = Color.Green;
            else
                lblScore.ForeColor = Color.White;

            hitBox.Left = Character.Right - (hitBox.Width + 20);
            hitBox.Top = Character.Top + 5;

            if (jumping)
            {
                Character.Top -= speed;

                if (Character.Top < defaultPosition - 140)
                {
                    speed = -10;
                }
                if (Character.Top > defaultPosition)
                {
                    jumping = false;
                    Character.Top = defaultPosition;
                    speed = 10;
                }
            }

            CheckCollision();

            if (score % 10 == 0 && score > 0 && backgroundState != score / 10)
            {
                backgroundState = score / 10;
                ChangeBackground();
            }

        }

        private void ChangeBackground()
        {
            if (obstaclesSpeed == 20) 
            {
                if (backgroundState % 2 == 0)
                {
                    if (random.Next(2) == 0)
                    {
                        backgroundImage = Properties.Resources.BGPixel1;
                        backgroundImage2 = Properties.Resources.BGPixel1;
                    }
                    else
                    {
                        backgroundImage = Properties.Resources.BGPixel3;
                        backgroundImage2 = Properties.Resources.BGPixel3;
                    }
                }
                else
                {
                    backgroundImage = Properties.Resources.BGPixel2;
                    backgroundImage2 = Properties.Resources.BGPixel2;
                }
            }
            else
            {
                if (backgroundState % 2 == 0)
                {
                    if (random.Next(2) == 0) 
                    {
                        backgroundImage = Properties.Resources.BGPixel2;
                        backgroundImage2 = Properties.Resources.BGPixel2;
                    }
                    else
                    {
                        backgroundImage = Properties.Resources.BGPixel3;
                        backgroundImage2 = Properties.Resources.BGPixel3;
                    }
                }
                else
                {
                    backgroundImage = Properties.Resources.BGPixel1;
                    backgroundImage2 = Properties.Resources.BGPixel1;
                }
            }
        }

        private void CheckCollision()
        {
            foreach (PictureBox x in obstacles)
            {
                if (x.Bounds.IntersectsWith(hitBox.Bounds))
                {
                    GameTimer.Stop();
                    Character.Image = Properties.Resources.Lose;
                    gameover = true;
                    HitSound = new SoundPlayer(localPath + @"/Audio/End.wav");
                    HitSound.Play();

                    if (score > HighestScore)
                    {
                        HighestScore = score;
                        lblHighestScore.Text = "Highest Score: " + HighestScore;

                        if (HighestScore > 30)
                        {
                            lblHighestScore.ForeColor = Color.Red;
                        }
                        else if (HighestScore > 20)
                        {
                            lblHighestScore.ForeColor = Color.Yellow;

                        }
                        else if (HighestScore > 10)
                        {
                            lblHighestScore.ForeColor = Color.Green;
                        }

                        SaveHighestScore();
                    }

                    Restart.Visible = true;
                    Exit.Visible = true;
                }
            }
        }

        private void SaveHighestScore()
        {
            File.WriteAllText(scoreFilePath, HighestScore.ToString());
        }
        private void MoveBackGrounds()
        {
            bgPositionX -= 1;
            bg2PositionX -= 1;

            if (bgPositionX < -backgroundWidth)
            {
                bgPositionX = bg2PositionX + backgroundWidth;
            }

            if (bg2PositionX < -backgroundWidth)
            {
                bg2PositionX = bgPositionX + backgroundWidth;
            }
        }
        private void MoveObstacles()
        {
            if (!flyingAttack)
            {
                obstacles1.Left -= obstaclesSpeed;
                obstacles2.Left -= obstaclesSpeed;
            }
            else
            {
                obstacles3.Left -= obstaclesSpeed;
            }

            if (attackTimer == attackR)
            {
                flyingAttack = true; ;
                attackR = random.Next(12, 20);
            }

            if (attackTimer == 0)
            {
                flyingAttack = false;
            }

            if (obstacles1.Left < -100)
            {
                obstacles1.Left = obstacles2.Left + obstacles2.Width + formWidth + random.Next(100, 300);
                attackTimer += 1;
                score += 1;
            }
            if (obstacles2.Left < -100)
            {
                obstacles2.Left = obstacles3.Left + obstacles3.Width + formWidth + random.Next(100, 300);
                attackTimer += 1;
                score += 1;
            }
            
            if (obstacles3.Left < -100)
            {
                obstacles3.Left = formWidth + random.Next(100, 200);
                obstacles3.Top = flyingPosition[random.Next(flyingPosition.Length)];
                attackTimer -= 1;
                score += 1;
            }
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            Form1 form1 = new Form1(); 
            form1.Show(); 
            this.Close();
        }
            private void btnExit_Click(object sender, EventArgs e)
        {
            HighestScore = 0;
            SaveHighestScore();
            Application.Exit();
        }
    }
}

