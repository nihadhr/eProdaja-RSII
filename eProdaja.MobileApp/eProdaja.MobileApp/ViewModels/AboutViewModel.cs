using eProdaja.MobileApp.Views;
using System;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eProdaja.MobileApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
            IncreaseCommand = new Command(Clicked);
            GetItems = new Command(OpenItems);

        }


        private async void OpenItems(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ItemsPage));
            //await Shell.Current.GoToAsync("//ItemsPage");
        }

        public ICommand IncreaseCommand { get; }
        int Count = 0;
        public string DisplayCount => $"You clicked {Count} times.";
        //public string DisplayCount ="You clicked times.";
        public ICommand GetItems { get;}
         
        void Clicked()
        {
            Count++;
            OnPropertyChanged(nameof(DisplayCount));
        }


        public ICommand OpenWebCommand { get; }
    }
}