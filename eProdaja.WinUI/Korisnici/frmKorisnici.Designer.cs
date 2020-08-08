namespace eProdaja.WinUI.Korisnici
{
    partial class frmKorisnici
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
            this.grb1 = new System.Windows.Forms.GroupBox();
            this.dgvTabela = new System.Windows.Forms.DataGridView();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.korisnickoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).BeginInit();
            this.SuspendLayout();
            // 
            // grb1
            // 
            this.grb1.Controls.Add(this.dgvTabela);
            this.grb1.Location = new System.Drawing.Point(12, 95);
            this.grb1.Name = "grb1";
            this.grb1.Size = new System.Drawing.Size(692, 343);
            this.grb1.TabIndex = 0;
            this.grb1.TabStop = false;
            this.grb1.Text = "Korisnici";
            this.grb1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvTabela
            // 
            this.dgvTabela.AllowUserToAddRows = false;
            this.dgvTabela.AllowUserToDeleteRows = false;
            this.dgvTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ime,
            this.prezime,
            this.korisnickoIme,
            this.status});
            this.dgvTabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTabela.Location = new System.Drawing.Point(3, 16);
            this.dgvTabela.Name = "dgvTabela";
            this.dgvTabela.ReadOnly = true;
            this.dgvTabela.Size = new System.Drawing.Size(686, 324);
            this.dgvTabela.TabIndex = 0;
            this.dgvTabela.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(12, 51);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(75, 23);
            this.btnPretraga.TabIndex = 1;
            this.btnPretraga.Text = "Pretraga";
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(12, 12);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(220, 20);
            this.txtIme.TabIndex = 2;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(464, 12);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(220, 20);
            this.txtPrezime.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(238, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(220, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "KorisnikID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ime
            // 
            this.ime.DataPropertyName = "ime";
            this.ime.HeaderText = "Ime";
            this.ime.Name = "ime";
            this.ime.ReadOnly = true;
            // 
            // prezime
            // 
            this.prezime.DataPropertyName = "prezime";
            this.prezime.HeaderText = "Prezime";
            this.prezime.Name = "prezime";
            this.prezime.ReadOnly = true;
            // 
            // korisnickoIme
            // 
            this.korisnickoIme.DataPropertyName = "korisnickoIme";
            this.korisnickoIme.HeaderText = "Korisnicko ime";
            this.korisnickoIme.Name = "korisnickoIme";
            this.korisnickoIme.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ime";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Prezime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Korisnicko ime";
            // 
            // frmKorisnici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.grb1);
            this.Name = "frmKorisnici";
            this.Text = "frmKorisnici";
            this.grb1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grb1;
        private System.Windows.Forms.DataGridView dgvTabela;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn korisnickoIme;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}