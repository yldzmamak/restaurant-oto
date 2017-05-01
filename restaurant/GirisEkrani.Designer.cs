namespace restaurant
{
    partial class GirisEkrani
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
            this.btnGiris = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbKullaniciAdi = new System.Windows.Forms.TextBox();
            this.tbSifre = new System.Windows.Forms.TextBox();
            this.lbHata = new System.Windows.Forms.Label();
            this.btnGirisEkrani = new System.Windows.Forms.Button();
            this.lbRestaurantName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGiris
            // 
            this.btnGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.Location = new System.Drawing.Point(263, 255);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(151, 36);
            this.btnGiris.TabIndex = 0;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(132, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(132, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Şifre:";
            // 
            // tbKullaniciAdi
            // 
            this.tbKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbKullaniciAdi.Location = new System.Drawing.Point(263, 140);
            this.tbKullaniciAdi.Name = "tbKullaniciAdi";
            this.tbKullaniciAdi.Size = new System.Drawing.Size(151, 27);
            this.tbKullaniciAdi.TabIndex = 3;
            // 
            // tbSifre
            // 
            this.tbSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbSifre.Location = new System.Drawing.Point(263, 184);
            this.tbSifre.Name = "tbSifre";
            this.tbSifre.PasswordChar = '*';
            this.tbSifre.Size = new System.Drawing.Size(151, 27);
            this.tbSifre.TabIndex = 4;
            // 
            // lbHata
            // 
            this.lbHata.AutoSize = true;
            this.lbHata.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbHata.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbHata.Location = new System.Drawing.Point(156, 292);
            this.lbHata.Name = "lbHata";
            this.lbHata.Size = new System.Drawing.Size(0, 20);
            this.lbHata.TabIndex = 5;
            // 
            // btnGirisEkrani
            // 
            this.btnGirisEkrani.BackgroundImage = global::restaurant.Properties.Resources.close_ikon;
            this.btnGirisEkrani.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGirisEkrani.FlatAppearance.BorderSize = 0;
            this.btnGirisEkrani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGirisEkrani.Location = new System.Drawing.Point(537, 12);
            this.btnGirisEkrani.Name = "btnGirisEkrani";
            this.btnGirisEkrani.Size = new System.Drawing.Size(39, 38);
            this.btnGirisEkrani.TabIndex = 6;
            this.btnGirisEkrani.UseVisualStyleBackColor = true;
            this.btnGirisEkrani.Click += new System.EventHandler(this.btnGirisEkrani_Click);
            // 
            // lbRestaurantName
            // 
            this.lbRestaurantName.AutoSize = true;
            this.lbRestaurantName.Font = new System.Drawing.Font("Castellar", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRestaurantName.Location = new System.Drawing.Point(57, 46);
            this.lbRestaurantName.Name = "lbRestaurantName";
            this.lbRestaurantName.Size = new System.Drawing.Size(445, 48);
            this.lbRestaurantName.TabIndex = 84;
            this.lbRestaurantName.Text = "STAR RESTAURANT";
            // 
            // GirisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(588, 394);
            this.Controls.Add(this.lbRestaurantName);
            this.Controls.Add(this.btnGirisEkrani);
            this.Controls.Add(this.lbHata);
            this.Controls.Add(this.tbSifre);
            this.Controls.Add(this.tbKullaniciAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGiris);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GirisEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GirisEkrani";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbHata;
        private System.Windows.Forms.TextBox tbKullaniciAdi;
        private System.Windows.Forms.TextBox tbSifre;
        private System.Windows.Forms.Button btnGirisEkrani;
        private System.Windows.Forms.Label lbRestaurantName;
    }
}

