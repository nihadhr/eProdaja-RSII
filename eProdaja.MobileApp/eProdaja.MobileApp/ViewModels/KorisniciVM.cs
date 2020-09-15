using eProdaja.MobileApp.Views;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eProdaja.MobileApp.ViewModels
{
    public class KorisniciVM
    {
        private readonly APIService _service = new APIService("Korisnik");
        public KorisniciVM()
        {
            InitCommand = new Command(async () => await Init());
            AddKorisnik = new Command(async () => await AddRedirect());
        }
        public ObservableCollection<Korisnici> KorisniciLista { get; set; } = new ObservableCollection<Korisnici>();
        public ICommand InitCommand { get; set; }
        public ICommand AddKorisnik { get; }
        public async Task Init()
        {
            var list =await _service.Get<IEnumerable<Korisnici>>(null);
            KorisniciLista.Clear();
            foreach(var x in list)
            {
                KorisniciLista.Add(x);
            }
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
