using eProdaja.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eProdaja.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _apiservice = new APIService("VrsteProizvoda");
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async() => await OnLoginClicked());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password 
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private async Task OnLoginClicked()
        {
            IsBusy = true;
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}"); 
            APIService.Username = Username;
            APIService.Password = Password;
            try
            {
                await _apiservice.Get<dynamic>(null);
                //frmLogin.ActiveForm.Close();
                Application.Current.MainPage = new AppShell();

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Neispravan username/password", "OK");       
            }
        }
    }
}
