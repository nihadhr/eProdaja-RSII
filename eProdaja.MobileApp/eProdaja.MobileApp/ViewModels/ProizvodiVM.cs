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
    public class ProizvodiVM
    {
        private readonly APIService _proizvodi = new APIService("Proizvod");
        public ProizvodiVM()
        {
            InitCommand = new Command(async() => await Init());
        }
        public ObservableCollection<Proizvod> ProizvodLista { get; set; } =new ObservableCollection<Proizvod>();

        public ICommand InitCommand { get; set; } //inicijalizuje bilo sta u VM
        
        public async Task Init()
        {
            var list = await  _proizvodi.Get<IEnumerable<Proizvod>>(null);
            ProizvodLista.Clear();
            foreach(var x in list)
            {
                ProizvodLista.Add(x);
            }
        }
    }
}
