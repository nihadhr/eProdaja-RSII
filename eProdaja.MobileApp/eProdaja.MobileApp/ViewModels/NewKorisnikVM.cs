﻿using eProdaja.MobileApp.Views;
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

namespace eProdaja.MobileApp.ViewModels
{
    [QueryProperty(nameof(KorisnikID), nameof(KorisnikID))]
    public class NewKorisnikVM:BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnik");
        private readonly APIService _service2 = new APIService("Uloge");
        public KorisniciInsert _request { get; set; }
        public ObservableCollection<Uloge> Uloge { get; set; } = new ObservableCollection<Uloge>();
        public string KorisnikID { get; set; }
        
        public NewKorisnikVM()
        {
            Save = new Command(async() => await SaveKorisnik());
            Cancel = new Command(async () => await Otkazi());
            OnLoad = new Command(async () => await Init());
            _request = new KorisniciInsert();
        }

        public async Task Init() 
            {
                if (KorisnikID != null)
                {
                    var korisnik = await _service.GetById<Model.Korisnici>(KorisnikID);
                    _request.Ime = korisnik.Ime; _request.Prezime = korisnik.Prezime; _request.Email = korisnik.Email;
                    _request.Telefon = korisnik.Telefon;
                }
                var list =await _service2.Get<IEnumerable<Model.Uloge>>(null);
            
            Uloge.Clear();
            foreach (var x in list)
                Uloge.Add(x);
             
        }


        
        public ICommand Save { get; }
        public ICommand Cancel { get; }
        public ICommand OnLoad { get; }
        
        async Task SaveKorisnik()
        {
            foreach(var x in Uloge)
            {
                if (x.IsChecked)
                    _request.Uloge.Add(x.UlogaId);
            }
            if(KorisnikID != null)
            {
                await _service.Update<Model.Korisnici>(KorisnikID, _request);
                await Application.Current.MainPage.DisplayAlert("", "Korisnik ažuriran !", "OK");
                await Shell.Current.GoToAsync("Page2");
                return;
            }
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
