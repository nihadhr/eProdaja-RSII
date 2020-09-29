using eProdaja.MobileApp.Views;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using Xamarin.Forms;

namespace eProdaja.MobileApp.ViewModels
{
    public class KorisniciVM:BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnik");
        //private Korisnici _selectedKorisnik;
        public KorisniciVM()
        {
            InitCommand = new Command(async () => await Init());
            AddKorisnik = new Command(async () => await AddRedirect());
            KorisnikTapped = new Command<Korisnici>(OnKorisnikSelected);
            KorisnikSwipped = new Command<Korisnici>(OnKorisnikSwipped);
        }
        //public Korisnici SelectedKorisnik
        //{
        //    get => _selectedKorisnik;
        //    set
        //    {
        //        SetProperty(ref _selectedKorisnik, value);
        //        OnKorisnikSelected(value);
        //    }
        //}
        async void OnKorisnikSelected(Korisnici obj)
        {
            if (obj == null)
                return;
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
            //await Shell.Current.GoToAsync($"{nameof(NewKorisnikPage)}?{nameof(NewKorisnikVM.KorisnikID)}={obj.KorisnikId}");
            await Shell.Current.GoToAsync($"{nameof(KorisnikDetailPage)}?{nameof(KorisnikDetailVM.KorisnikID)}={obj.KorisnikId}");
        }
        async void OnKorisnikSwipped(Korisnici obj)
        {    
            if (obj == null)
                return;
           bool answer=await App.Current.MainPage.DisplayAlert("Delete user", "Delete user "+obj.KorisnickoIme, "Yes", "No");
            if (answer)
            {
              var user= await _service.Delete<Model.Korisnici>(obj.KorisnikId);
                KorisniciLista.Remove(obj);
               await App.Current.MainPage.DisplayAlert("Delete user", "User is deleted !","OK");
            }
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
            //await Shell.Current.GoToAsync($"{nameof(NewKorisnikPage)}?{nameof(NewKorisnikVM.KorisnikID)}={obj.KorisnikId}");
            //await Shell.Current.GoToAsync($"{nameof(KorisnikDetailPage)}?{nameof(KorisnikDetailVM.KorisnikID)}={obj.KorisnikId}");
        }

        public ObservableCollection<Korisnici> KorisniciLista { get; set; } = new ObservableCollection<Korisnici>();
        public ICommand InitCommand { get; set; }
        public ICommand AddKorisnik { get; }
        public Command<Korisnici> KorisnikTapped { get; }
        public Command<Korisnici> KorisnikSwipped { get; }
        public int KorisnikId { get; set; }

        public async Task Init()
        {
            var list =await _service.Get<IEnumerable<Korisnici>>(null);
            KorisniciLista.Clear();
            foreach(var x in list)
            {
                KorisniciLista.Add(x);
            }
        }
        public async Task Edit()
        {
            await Shell.Current.GoToAsync($"NewKorisnikPage?ID={KorisnikId}"); // proslijedit postojeceg tj ID proslijedit 
        }
        //public async Task Redirect(Korisnici korisnik)
        //{
        //    if (korisnik == null) return;
        //    await Shell.Current.GoToAsync($"{nameof(EditKorisnikPage)}?{nameof(KorisniciVM.ItemId)}={item.Id}");
        //}
        public async Task AddRedirect()
        {
            await Shell.Current.GoToAsync(nameof(NewKorisnikPage));

        }
    }
}
