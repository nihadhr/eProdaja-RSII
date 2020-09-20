using eProdaja.MobileApp.ViewModels;
using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eProdaja.MobileApp.Views
{
    [QueryProperty(nameof(KorisnikID), nameof(KorisnikID))]
    public class KorisnikDetailVM:BaseViewModel
    {
        public KorisnikDetailVM()
        {
            Save = new Command(SaveChanges);
            Cancel = new Command(async() => await Shell.Current.GoToAsync("Page2"));

        }
        public APIService _service = new APIService("Korisnik");
        public APIService _service2 = new APIService("Uloge");
        public APIService _service3 = new APIService("KorisniciUloge");
        public ObservableCollection<Uloge> Uloge { get; set; } = new ObservableCollection<Uloge>();
        public ICommand Cancel { get; set; }
        public ICommand Save { get; set; }
        public string KorisnikID { get; set; }
        public string ime;
        public string prezime;
        public string email;
        public string korisnicko;
        public string telefon;
        public bool aktivan;
        public string password;
        public string password2;
        public string Ime { get { return ime; } set { SetProperty(ref ime, value); } }
        public string Prezime { get => ime; set => SetProperty(ref prezime, value); }
        public string Email { get => email; set => SetProperty(ref email, value); }
        public string Korisnicko { get => korisnicko; set => SetProperty(ref korisnicko, value); }
        public string Telefon { get => telefon; set => SetProperty(ref telefon, value); }
        public bool Aktivan { get => aktivan; set => SetProperty(ref aktivan, value); }
        public string Password { get => password; set => SetProperty(ref password, value); }
        public string PasswordConfirmation{ get => password2; set => SetProperty(ref password2, value); }

        public async Task LoadKorisnik()
        {
            var korisnik = await _service.GetById<Model.Korisnici>(KorisnikID);
            Ime = korisnik.Ime; Prezime = korisnik.Prezime; Email = korisnik.Email;
            Telefon = korisnik.Telefon; Korisnicko = korisnik.KorisnickoIme; Aktivan = (bool)korisnik.Status;

            var oznaceneuloge = await _service3.Get<List<Model.KorisniciUloge>>(KorisnikID);
            var list = await _service2.Get<IEnumerable<Model.Uloge>>(null);

            Uloge.Clear();
            foreach (var x in list)
            {
                if (oznaceneuloge.Any(s => s.UlogaId == x.UlogaId)) { x.IsChecked = true; }
                Uloge.Add(x);
            }


        }
        public async void SaveChanges()
        {
           
            if (KorisnikID != null)
            {
                var obj = new KorisniciInsert { Ime = this.ime, Prezime = this.prezime, Email = this.email, Telefon = this.telefon, KorisnickoIme = this.korisnicko, Status = aktivan, Password =this.password, PasswordConfirmation =this.password };
                foreach(var x in Uloge)
                {
                    if (x.IsChecked) { obj.Uloge.Add(x.UlogaId); }
                }
                await _service.Update<Model.Korisnici>(KorisnikID,obj);
                await Application.Current.MainPage.DisplayAlert("", "Korisnik ažuriran !", "OK");
                await Shell.Current.GoToAsync("Page2");
            }
            
        }

    }
}
