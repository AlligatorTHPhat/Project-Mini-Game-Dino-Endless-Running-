namespace Project_Game_Dino_Endless_Running
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lblHighestScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.obstacles3 = new System.Windows.Forms.PictureBox();
            this.obstacles1 = new System.Windows.Forms.PictureBox();
            this.obstacles2 = new System.Windows.Forms.PictureBox();
            this.Character = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.obstacles3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacles1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacles2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Character)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHighestScore
            // 
            this.lblHighestScore.AutoSize = true;
            this.lblHighestScore.Location = new System.Drawing.Point(30, 61);
            this.lblHighestScore.Name = "lblHighestScore";
            this.lblHighestScore.Size = new System.Drawing.Size(89, 16);
            this.lblHighestScore.TabIndex = 7;
            this.lblHighestScore.Text = "HighestScore";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(30, 15);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(43, 16);
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "Score";
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 15;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // obstacles3
            // 
            this.obstacles3.BackColor = System.Drawing.Color.Transparent;
            this.obstacles3.Image = global::Project_Game_Dino_Endless_Running.Properties.Resources.Bird;
            this.obstacles3.Location = new System.Drawing.Point(911, 474);
            this.obstacles3.Name = "obstacles3";
            this.obstacles3.Size = new System.Drawing.Size(95, 76);
            this.obstacles3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obstacles3.TabIndex = 12;
            this.obstacles3.TabStop = false;
            this.obstacles3.Tag = "obstacles";
            // 
            // obstacles1
            // 
            this.obstacles1.BackColor = System.Drawing.Color.Transparent;
            this.obstacles1.Image = global::Project_Game_Dino_Endless_Running.Properties.Resources.ObsStone;
            this.obstacles1.Location = new System.Drawing.Point(414, 490);
            this.obstacles1.Name = "obstacles1";
            this.obstacles1.Size = new System.Drawing.Size(70, 60);
            this.obstacles1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obstacles1.TabIndex = 11;
            this.obstacles1.TabStop = false;
            this.obstacles1.Tag = "obstacles";
            // 
            // obstacles2
            // 
            this.obstacles2.BackColor = System.Drawing.Color.Transparent;
            this.obstacles2.ErrorImage = null;
            this.obstacles2.Image = global::Project_Game_Dino_Endless_Running.Properties.Resources.ObsTree;
            this.obstacles2.InitialImage = null;
            this.obstacles2.Location = new System.Drawing.Point(714, 443);
            this.obstacles2.Name = "obstacles2";
            this.obstacles2.Size = new System.Drawing.Size(117, 107);
            this.obstacles2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obstacles2.TabIndex = 9;
            this.obstacles2.TabStop = false;
            this.obstacles2.Tag = "obstacles";
            // 
            // Character
            // 
            this.Character.BackColor = System.Drawing.Color.Transparent;
            this.Character.Image = global::Project_Game_Dino_Endless_Running.Properties.Resources.Running;
            this.Character.Location = new System.Drawing.Point(189, 450);
            this.Character.Name = "Character";
            this.Character.Size = new System.Drawing.Size(100, 100);
            this.Character.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Character.TabIndex = 8;
            this.Character.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 703);
            this.Controls.Add(this.obstacles3);
            this.Controls.Add(this.obstacles1);
            this.Controls.Add(this.obstacles2);
            this.Controls.Add(this.Character);
            this.Controls.Add(this.lblHighestScore);
            this.Controls.Add(this.lblScore);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Trex Endless Running";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPaintEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.obstacles3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacles1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacles2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Character)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox obstacles1;
        private System.Windows.Forms.PictureBox obstacles2;
        private System.Windows.Forms.PictureBox Character;
        private System.Windows.Forms.Label lblHighestScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox obstacles3;
        private System.Windows.Forms.Timer GameTimer;
    }
}