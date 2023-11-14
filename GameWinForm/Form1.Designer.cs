namespace GameWinForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.FightMonster = new System.Windows.Forms.Button();
            this.ChangeLocation = new System.Windows.Forms.Button();
            this.DropItemMonsterBG = new System.Windows.Forms.PictureBox();
            this.ItemDropMob = new System.Windows.Forms.DataGridView();
            this.KillLog = new System.Windows.Forms.Label();
            this.CloseItemDrop = new System.Windows.Forms.Button();
            this.ShopSpell = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DropItemMonsterBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDropMob)).BeginInit();
            this.SuspendLayout();
            // 
            // FightMonster
            // 
            this.FightMonster.Location = new System.Drawing.Point(261, 469);
            this.FightMonster.Name = "FightMonster";
            this.FightMonster.Size = new System.Drawing.Size(151, 58);
            this.FightMonster.TabIndex = 0;
            this.FightMonster.Text = "Охотиться на монстров";
            this.FightMonster.UseVisualStyleBackColor = true;
            this.FightMonster.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangeLocation
            // 
            this.ChangeLocation.Location = new System.Drawing.Point(843, 469);
            this.ChangeLocation.Margin = new System.Windows.Forms.Padding(2);
            this.ChangeLocation.Name = "ChangeLocation";
            this.ChangeLocation.Size = new System.Drawing.Size(154, 58);
            this.ChangeLocation.TabIndex = 1;
            this.ChangeLocation.Text = "Сменить локацию";
            this.ChangeLocation.UseVisualStyleBackColor = true;
            this.ChangeLocation.Click += new System.EventHandler(this.смена_окации_Click);
            // 
            // DropItemMonsterBG
            // 
            this.DropItemMonsterBG.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.DropItemMonsterBG.Location = new System.Drawing.Point(191, 78);
            this.DropItemMonsterBG.Name = "DropItemMonsterBG";
            this.DropItemMonsterBG.Size = new System.Drawing.Size(871, 449);
            this.DropItemMonsterBG.TabIndex = 2;
            this.DropItemMonsterBG.TabStop = false;
            this.DropItemMonsterBG.Click += new System.EventHandler(this.DropItemMonsterBG_Click);
            // 
            // ItemDropMob
            // 
            this.ItemDropMob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemDropMob.Location = new System.Drawing.Point(413, 175);
            this.ItemDropMob.Name = "ItemDropMob";
            this.ItemDropMob.Size = new System.Drawing.Size(400, 209);
            this.ItemDropMob.TabIndex = 3;
            this.ItemDropMob.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemDropMob_CellContentClick);
            // 
            // KillLog
            // 
            this.KillLog.AutoSize = true;
            this.KillLog.Location = new System.Drawing.Point(498, 116);
            this.KillLog.Name = "KillLog";
            this.KillLog.Size = new System.Drawing.Size(35, 13);
            this.KillLog.TabIndex = 4;
            this.KillLog.Text = "label1";
            this.KillLog.Click += new System.EventHandler(this.KillLog_Click);
            // 
            // CloseItemDrop
            // 
            this.CloseItemDrop.Location = new System.Drawing.Point(592, 452);
            this.CloseItemDrop.Name = "CloseItemDrop";
            this.CloseItemDrop.Size = new System.Drawing.Size(75, 23);
            this.CloseItemDrop.TabIndex = 5;
            this.CloseItemDrop.Text = "OK";
            this.CloseItemDrop.UseVisualStyleBackColor = true;
            this.CloseItemDrop.Click += new System.EventHandler(this.CloseItemDrop_Click);
            // 
            // ShopSpell
            // 
            this.ShopSpell.Location = new System.Drawing.Point(261, 558);
            this.ShopSpell.Name = "ShopSpell";
            this.ShopSpell.Size = new System.Drawing.Size(151, 58);
            this.ShopSpell.TabIndex = 6;
            this.ShopSpell.Text = "Купить заклинания";
            this.ShopSpell.UseVisualStyleBackColor = true;
            this.ShopSpell.Click += new System.EventHandler(this.ShopSpell_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.ShopSpell);
            this.Controls.Add(this.ChangeLocation);
            this.Controls.Add(this.FightMonster);
            this.Controls.Add(this.CloseItemDrop);
            this.Controls.Add(this.KillLog);
            this.Controls.Add(this.ItemDropMob);
            this.Controls.Add(this.DropItemMonsterBG);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DropItemMonsterBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDropMob)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FightMonster;
        private System.Windows.Forms.Button ChangeLocation;
        private System.Windows.Forms.PictureBox DropItemMonsterBG;
        private System.Windows.Forms.DataGridView ItemDropMob;
        private System.Windows.Forms.Label KillLog;
        private System.Windows.Forms.Button CloseItemDrop;
        private System.Windows.Forms.Button ShopSpell;
    }
}

