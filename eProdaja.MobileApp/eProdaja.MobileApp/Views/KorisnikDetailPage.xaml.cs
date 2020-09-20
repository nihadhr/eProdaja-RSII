using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eProdaja.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KorisnikDetailPage : ContentPage
    {
        KorisnikDetailVM model;
        public KorisnikDetailPage()
        {
            InitializeComponent();
            BindingContext=model=new KorisnikDetailVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadKorisnik();
        }
    }
}