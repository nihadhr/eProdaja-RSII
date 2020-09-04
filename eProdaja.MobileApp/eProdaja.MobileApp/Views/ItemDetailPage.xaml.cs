using System.ComponentModel;
using Xamarin.Forms;
using eProdaja.MobileApp.ViewModels;

namespace eProdaja.MobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}