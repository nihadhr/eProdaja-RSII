using eProdaja.MobileApp.ViewModels;
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
    public partial class NewKorisnikPage : ContentPage
    {
        NewKorisnikVM model = null;

        public NewKorisnikPage()
        {
            InitializeComponent();
            BindingContext = model = new NewKorisnikVM();
        }
       
    }
}