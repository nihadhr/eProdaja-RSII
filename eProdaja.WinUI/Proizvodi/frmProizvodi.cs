using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI.Proizvodi
{
    public partial class frmProizvodi : Form
    {
        private readonly APIService _vrsteProizvoda=new APIService("VrsteProizvoda");
        private readonly APIService _jediniceMjere = new APIService("JediniceMjere");
        private readonly APIService _proizvodi = new APIService("Proizvod");
        public frmProizvodi()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void frmProizvodi_Load(object sender, EventArgs e)
        {
            await LoadVrsteProizvoda(); await LoadJedinicaMjere();
        }
        private async Task LoadVrsteProizvoda()
        {
            var result = await _vrsteProizvoda.Get<List<Model.VrsteProizvoda>>(null);
            result.Insert(0, new Model.VrsteProizvoda());
            cmbVrsteProizvoda.DisplayMember = "Naziv";
            cmbVrsteProizvoda.ValueMember = "VrstaId";
            cmbVrsteProizvoda.DataSource = result;
        }
        private async Task LoadJedinicaMjere()
        {
            var result = await _jediniceMjere.Get<List<Model.JediniceMjere>>(null);
            result.Insert(0, new Model.JediniceMjere());
            cmbJediniceMjere.DisplayMember = "Naziv";
            cmbJediniceMjere.ValueMember = "JedinicaMjereId";
            cmbJediniceMjere.DataSource = result;
        }

        private void cmbVrsteProizvoda_ValueMemberChanged(object sender, EventArgs e)
        {
            
        }

        private async void cmbVrsteProizvoda_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = cmbVrsteProizvoda.SelectedValue;
            if(int.TryParse(value.ToString(),out int id))
            {
                await LoadProizvodi(id);
            }
        }
        private async Task LoadProizvodi(int id)
        {
            var result = await _proizvodi.Get<List<Model.Proizvod>>(new ProizvodSearchRequest() { VrstaId = id });
            dgvTabela.DataSource = result;
            
        }
        ProizvodUpsertRequest novi = new ProizvodUpsertRequest();
        private async void btnSave_Click(object sender, EventArgs e)
        {
            
            var idObj = cmbVrsteProizvoda.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int vrstaId))
            {
                novi.VrstaId = vrstaId;
            }
            var idJed = cmbJediniceMjere.SelectedValue;
            if (int.TryParse(idJed.ToString(), out int jedID))
            {
                novi.JedinicaMjereId = jedID;
            }
            novi.Naziv = txtNaziv.Text;
            novi.Sifra = txtSifra.Text;
            await _proizvodi.Insert<Model.Proizvod>(novi);
            
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                novi.Slika = file;
                txtSlikaInput.Text = fileName;
                Image img = Image.FromFile(fileName);
             
                pictureBox1.Image = img;
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void txtSlikaInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
