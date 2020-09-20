using System;
using System.Collections.Generic;
using eProdaja.MobileApp.ViewModels;
using eProdaja.MobileApp.Views;
using Xamarin.Forms;

namespace eProdaja.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
            Routing.RegisterRoute(nameof(ProizvodiPage), typeof(ProizvodiPage));
            Routing.RegisterRoute(nameof(Page1), typeof(Page1));
            Routing.RegisterRoute(nameof(Page2), typeof(Page2));
            Routing.RegisterRoute(nameof(NewKorisnikPage), typeof(NewKorisnikPage));
            Routing.RegisterRoute(nameof(KorisnikDetailPage), typeof(KorisnikDetailPage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
