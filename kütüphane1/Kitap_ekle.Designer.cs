namespace kütüphane1
{
    partial class Kitap_ekle
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ekle2_btn = new System.Windows.Forms.Button();
            this.kitap_sil_btn = new System.Windows.Forms.Button();
            this.kitap_bak_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(142, 129);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(130, 22);
            this.textBox3.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(142, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 22);
            this.textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 22);
            this.textBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "ISBN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Yazar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Kitap Adı";
            // 
            // ekle2_btn
            // 
            this.ekle2_btn.Location = new System.Drawing.Point(48, 180);
            this.ekle2_btn.Name = "ekle2_btn";
            this.ekle2_btn.Size = new System.Drawing.Size(224, 54);
            this.ekle2_btn.TabIndex = 3;
            this.ekle2_btn.Text = "Kitap Ekle";
            this.ekle2_btn.UseVisualStyleBackColor = true;
            this.ekle2_btn.Click += new System.EventHandler(this.ekle2_btn_Click);
            // 
            // kitap_sil_btn
            // 
            this.kitap_sil_btn.Location = new System.Drawing.Point(48, 240);
            this.kitap_sil_btn.Name = "kitap_sil_btn";
            this.kitap_sil_btn.Size = new System.Drawing.Size(224, 56);
            this.kitap_sil_btn.TabIndex = 12;
            this.kitap_sil_btn.Text = "Kitap Sil";
            this.kitap_sil_btn.UseVisualStyleBackColor = true;
            this.kitap_sil_btn.Click += new System.EventHandler(this.kitap_sil_btn_Click);
            // 
            // kitap_bak_btn
            // 
            this.kitap_bak_btn.Location = new System.Drawing.Point(48, 302);
            this.kitap_bak_btn.Name = "kitap_bak_btn";
            this.kitap_bak_btn.Size = new System.Drawing.Size(224, 56);
            this.kitap_bak_btn.TabIndex = 13;
            this.kitap_bak_btn.Text = "Kitapları Görüntüle";
            this.kitap_bak_btn.UseVisualStyleBackColor = true;
            this.kitap_bak_btn.Click += new System.EventHandler(this.kitap_bak_btn_Click);
            // 
            // Kitap_ekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 370);
            this.Controls.Add(this.kitap_bak_btn);
            this.Controls.Add(this.kitap_sil_btn);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ekle2_btn);
            this.MaximizeBox = false;
            this.Name = "Kitap_ekle";
            this.Text = "Kitap İşlemleri";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ekle2_btn;
        private System.Windows.Forms.Button kitap_sil_btn;
        private System.Windows.Forms.Button kitap_bak_btn;
    }
}