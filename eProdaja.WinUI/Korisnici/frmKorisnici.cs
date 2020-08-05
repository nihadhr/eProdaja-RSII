using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using eProdaja.Model.Requests;

namespace eProdaja.WinUI.Korisnici
{
    public partial class frmKorisnici : Form
    {
        private readonly APIService _apiservice = new APIService("Korisnik");
        public frmKorisnici()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var rikvest = new KorisniciSearchRequest {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text
            };


            var result = await _apiservice.Get<List<Model.Korisnici>>(rikvest);
            dgvTabela.DataSource = result;
        }

      
    }
}
