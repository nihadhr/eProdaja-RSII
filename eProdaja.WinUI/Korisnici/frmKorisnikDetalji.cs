using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI.Korisnici
{
    public partial class frmKorisnikDetalji : Form
    {
        private APIService _apiservice = new APIService("Korisnik");
        private APIService _apiservice2 = new APIService("Uloge");
        private int? _id = null;
        public frmKorisnikDetalji(int? id=null)
        {
            InitializeComponent();
            _id = id;
        }
        private async void frmKorisnikDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var obj = await _apiservice.GetById<Model.Korisnici>(_id);
                txtIme.Text = obj.Ime; txtPrezime.Text= obj.Prezime;
                txtKorisnicko.Text = obj.KorisnickoIme; txtEmail.Text = obj.Email;
                txtTelefon.Text = obj.Telefon;
            }
            var uloge = await _apiservice2.Get<List<Model.Uloge>>(null);
            clbUloge.DisplayMember = "Role";
            clbUloge.DataSource = uloge; 

        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
         
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //var txtboxes = this.Controls.OfType<TextBox>().ToList();

            //if (txtboxes.Any(s=>s.TextLength==0)) {

            //    string msg = "Sva polja su obavezna !"; string caption = "Greška pri unosu";
            //    MessageBoxButtons oki = MessageBoxButtons.OK;
            //    DialogResult res = MessageBox.Show(msg, caption, oki);
            //    if (res == System.Windows.Forms.DialogResult.OK)
            //    {
            //        this.Refresh();
            //    }

            //}
            if (this.ValidateChildren())
            {
                var uloge = clbUloge.CheckedItems.Cast<Model.Uloge>().Select(a=>a.UlogaId).ToList();
                var objekt = new KorisniciInsert
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Email = txtEmail.Text,
                    KorisnickoIme = txtKorisnicko.Text,
                    Telefon = txtTelefon.Text,
                    Password = txtLozinka.Text,
                    PasswordConfirmation = txtLozinka1.Text,
                    Status = chxAktivan.Checked,
                    Uloge=uloge

                    
                };
                if (_id.HasValue)
                {
                    await _apiservice.Update<Model.Korisnici>(_id, objekt);
                }
                else
                {
                    await _apiservice.Insert<Model.Korisnici>(objekt);
                }
                MessageBox.Show("Uspjesno sacuvano !");
                
            }
            
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider1.SetError(txtIme,Properties.Resources.Validation_RequiredField_BS);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider1.SetError(txtPrezime, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPrezime, null);
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, Properties.Resources.Validation_RequiredField_BS);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                errorProvider1.SetError(txtTelefon, Properties.Resources.Validation_RequiredField_BS);
                e.Cancel = true;
            }
            else if(!Regex.Match(txtTelefon.Text, "[+3876][0-9]{7,8}").Success)
            {
                errorProvider1.SetError(txtTelefon, "Pogrešan format broja [+3876x]");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTelefon, null);
            }
        }

        private void txtKorisnicko_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnicko.Text))
            {
                errorProvider1.SetError(txtKorisnicko, Properties.Resources.Validation_RequiredField_BS);
                e.Cancel = true;
            }
            else if(txtKorisnicko.Text.Length < 3)
            {
                errorProvider1.SetError(txtKorisnicko, "Minimalno tri karaktera");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtKorisnicko, null); 
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
             
        }
    }
}
