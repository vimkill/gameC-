namespace GameWinForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Weapon = new System.Windows.Forms.Button();
            this.Potion = new System.Windows.Forms.Button();
            this.Universe1 = new System.Windows.Forms.DataGridView();
            this.Monster = new System.Windows.Forms.PictureBox();
            this.SkipMovie = new System.Windows.Forms.PictureBox();
            this.Waring = new System.Windows.Forms.Label();
            this.Spell = new System.Windows.Forms.Button();
            this.BackMainMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Universe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Monster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkipMovie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackMainMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1217, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // Weapon
            // 
            this.Weapon.Location = new System.Drawing.Point(284, 486);
            this.Weapon.Name = "Weapon";
            this.Weapon.Size = new System.Drawing.Size(178, 47);
            this.Weapon.TabIndex = 2;
            this.Weapon.Text = "Weapon";
            this.Weapon.UseVisualStyleBackColor = true;
            this.Weapon.Click += new System.EventHandler(this.Weapon_Click);
            // 
            // Potion
            // 
            this.Potion.Location = new System.Drawing.Point(756, 486);
            this.Potion.Name = "Potion";
            this.Potion.Size = new System.Drawing.Size(178, 46);
            this.Potion.TabIndex = 3;
            this.Potion.Text = "Potion";
            this.Potion.UseVisualStyleBackColor = true;
            this.Potion.Click += new System.EventHandler(this.Potion_Click);
            // 
            // Universe1
            // 
            this.Universe1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Universe1.Location = new System.Drawing.Point(127, 47);
            this.Universe1.Name = "Universe1";
            this.Universe1.Size = new System.Drawing.Size(970, 485);
            this.Universe1.TabIndex = 4;
            this.Universe1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Universe1_CellContentClick);
            // 
            // Monster
            // 
            this.Monster.Location = new System.Drawing.Point(475, 177);
            this.Monster.Name = "Monster";
            this.Monster.Size = new System.Drawing.Size(256, 256);
            this.Monster.TabIndex = 5;
            this.Monster.TabStop = false;
            // 
            // SkipMovie
            // 
            this.SkipMovie.Location = new System.Drawing.Point(940, 605);
            this.SkipMovie.Name = "SkipMovie";
            this.SkipMovie.Size = new System.Drawing.Size(64, 64);
            this.SkipMovie.TabIndex = 0;
            this.SkipMovie.TabStop = false;
            this.SkipMovie.Click += new System.EventHandler(this.SkipMovie_Click);
            // 
            // Waring
            // 
            this.Waring.AutoSize = true;
            this.Waring.Location = new System.Drawing.Point(332, 293);
            this.Waring.Name = "Waring";
            this.Waring.Size = new System.Drawing.Size(35, 13);
            this.Waring.TabIndex = 6;
            this.Waring.Text = "label3";
            this.Waring.Click += new System.EventHandler(this.Waring_Click);
            // 
            // Spell
            // 
            this.Spell.Location = new System.Drawing.Point(756, 556);
            this.Spell.Name = "Spell";
            this.Spell.Size = new System.Drawing.Size(178, 46);
            this.Spell.TabIndex = 7;
            this.Spell.Text = "Spell";
            this.Spell.UseVisualStyleBackColor = true;
            this.Spell.Click += new System.EventHandler(this.Spell_Click);
            // 
            // BackMainMenu
            // 
            this.BackMainMenu.Location = new System.Drawing.Point(1103, 538);
            this.BackMainMenu.Name = "BackMainMenu";
            this.BackMainMenu.Size = new System.Drawing.Size(64, 64);
            this.BackMainMenu.TabIndex = 8;
            this.BackMainMenu.TabStop = false;
            this.BackMainMenu.Click += new System.EventHandler(this.BackMainMenu_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.BackMainMenu);
            this.Controls.Add(this.Spell);
            this.Controls.Add(this.Waring);
            this.Controls.Add(this.SkipMovie);
            this.Controls.Add(this.Monster);
            this.Controls.Add(this.Potion);
            this.Controls.Add(this.Weapon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Universe1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.Universe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Monster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkipMovie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackMainMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Weapon;
        private System.Windows.Forms.Button Potion;
        private System.Windows.Forms.DataGridView Universe1;
        private System.Windows.Forms.PictureBox Monster;
        private System.Windows.Forms.PictureBox SkipMovie;
        private System.Windows.Forms.Label Waring;
        private System.Windows.Forms.Button Spell;
        private System.Windows.Forms.PictureBox BackMainMenu;
    }
}