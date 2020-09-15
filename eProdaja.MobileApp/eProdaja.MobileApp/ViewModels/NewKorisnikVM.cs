using eProdaja.MobileApp.Views;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eProdaja.MobileApp.ViewModels
{
    public class NewKorisnikVM
    {
        private readonly APIService _service = new APIService("Korisnik");
        
        public NewKorisnikVM()
        {
            Save = new Command(async() => await SaveKorisnik());
            Cancel = new Command(async () => await Otkazi());
            //_request = new KorisniciInsert();
        }
        public KorisniciInsert _request { get; set; } = new KorisniciInsert();
        public ICommand Save { get; }
        public ICommand Cancel { get; }
        async Task SaveKorisnik()
        {
            await _service.Insert<Model.Korisnici>(_request);
            await Application.Current.MainPage.DisplayAlert("", "Korisnik sačuvan !", "OK");

            await Shell.Current.GoToAsync("..");

        }
        private async Task Otkazi()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("Page2");
        }
    }
}
