using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            cmbVrsteProizvoda.DisplayMember = "Naziv";
            cmbVrsteProizvoda.ValueMember = "VrstaId";
            cmbVrsteProizvoda.DataSource = result;
        }
        private async Task LoadJedinicaMjere()
        {
            var result = await _jediniceMjere.Get<List<Model.JediniceMjere>>(null);
            cmbJediniceMjere.DisplayMember = "Naziv";
            cmbJediniceMjere.ValueMember = "JedinicaMjereId";
            cmbJediniceMjere.DataSource = result;
        }
    }
}
