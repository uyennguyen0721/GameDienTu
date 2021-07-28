namespace GameTiengAnhDienTu
{
    partial class WordFillGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordFillGame));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btSound = new GameTiengAnhDienTu.RoundButton1();
            this.btNotSound = new GameTiengAnhDienTu.RoundButton1();
            this.btPlay = new GameTiengAnhDienTu.RoundedButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btNotSound)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(187, 12);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(424, 277);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(97, 100);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(209, 158);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(341, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Kristen ITC", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(20, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Học Tiếng Anh Cùng";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Ravie", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(45)))), ((int)(((byte)(125)))));
            this.label2.Location = new System.Drawing.Point(99, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(576, 83);
            this.label2.TabIndex = 1;
            this.label2.Text = "Word Fill Game";
            // 
            // timer1
            // 
            this.timer1.Interval = 850;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btSound
            // 
            this.btSound.Image = ((System.Drawing.Image)(resources.GetObject("btSound.Image")));
            this.btSound.Location = new System.Drawing.Point(686, 458);
            this.btSound.Name = "btSound";
            this.btSound.Size = new System.Drawing.Size(52, 52);
            this.btSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btSound.TabIndex = 4;
            this.btSound.TabStop = false;
            this.btSound.Click += new System.EventHandler(this.btSound_Click);
            this.btSound.MouseEnter += new System.EventHandler(this.btNotSound_MouseEnter);
            this.btSound.MouseLeave += new System.EventHandler(this.btNotSound_MouseLeave);
            // 
            // btNotSound
            // 
            this.btNotSound.Image = ((System.Drawing.Image)(resources.GetObject("btNotSound.Image")));
            this.btNotSound.Location = new System.Drawing.Point(686, 458);
            this.btNotSound.Name = "btNotSound";
            this.btNotSound.Size = new System.Drawing.Size(52, 52);
            this.btNotSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btNotSound.TabIndex = 4;
            this.btNotSound.TabStop = false;
            this.btNotSound.Click += new System.EventHandler(this.btNotSound_Click);
            this.btNotSound.MouseEnter += new System.EventHandler(this.btNotSound_MouseEnter);
            this.btNotSound.MouseLeave += new System.EventHandler(this.btNotSound_MouseLeave);
            // 
            // btPlay
            // 
            this.btPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btPlay.Font = new System.Drawing.Font("Kristen ITC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPlay.ForeColor = System.Drawing.Color.White;
            this.btPlay.Location = new System.Drawing.Point(295, 458);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(190, 70);
            this.btPlay.TabIndex = 3;
            this.btPlay.Text = "Play Now";
            this.btPlay.UseVisualStyleBackColor = false;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            this.btPlay.MouseEnter += new System.EventHandler(this.btPlay_MouseEnter);
            this.btPlay.MouseLeave += new System.EventHandler(this.btPlay_MouseLeave);
            // 
            // WordFillGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.btSound);
            this.Controls.Add(this.btNotSound);
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WordFillGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Word Fill Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WordFillGame_FormClosing);
            this.Load += new System.EventHandler(this.WordFillGame_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btNotSound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private RoundedButton btPlay;
        private RoundButton1 btNotSound;
        private RoundButton1 btSound;
    }
}

