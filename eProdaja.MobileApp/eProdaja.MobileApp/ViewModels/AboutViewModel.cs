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
            
        }
        public ICommand IncreaseCommand { get; }
        int Count = 0;
        public string DisplayCount => $"You clicked {Count} times.";
        //public string DisplayCount ="You clicked times.";
         
        void Clicked()
        {
            Count++;
            OnPropertyChanged(nameof(DisplayCount));
        }

        public ICommand OpenWebCommand { get; }
    }
}