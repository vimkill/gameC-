namespace GameWinForm
{
    partial class Form4
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
            this.dataGridPotion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPotion)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPotion
            // 
            this.dataGridPotion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPotion.Location = new System.Drawing.Point(0, 0);
            this.dataGridPotion.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridPotion.Name = "dataGridPotion";
            this.dataGridPotion.RowHeadersWidth = 51;
            this.dataGridPotion.RowTemplate.Height = 24;
            this.dataGridPotion.Size = new System.Drawing.Size(1280, 682);
            this.dataGridPotion.TabIndex = 0;
            this.dataGridPotion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPotion_CellContentClick);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dataGridPotion);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPotion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPotion;
    }
}