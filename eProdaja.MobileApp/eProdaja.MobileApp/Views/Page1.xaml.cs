using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eProdaja.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            //switch (Device.RuntimePlatform)   //device.onplatfrom is OBSOLETE
            //{
            //    case Device.iOS:
            //        Padding = new Thickness(0, 20, 0, 0);
            //            break;
            //    case Device.Android:
            //        Padding = new Thickness(5, 5, 5, 5);
            //        break;
            //    case Device.UWP:
            //        Padding = new Thickness(0, 20, 0, 0);
            //        break;

            //}
            CurrentTxt.Text = Quotes[n];
        } 

             public List<string> Quotes = new List<string> {
        "Ko drugom jamu kopa, sam u nju pada !",
         "Ko rano rani, dvije sreće grabi !",
        "Enter a quote "};

        public int n = 0;
        //public string Current;
 

        void Button_Clicked(object sender, EventArgs e)
        {
            n++;
            if (n == Quotes.Count()) { n = 0; }
            CurrentTxt.Text = Quotes[n];
        }
    }
}