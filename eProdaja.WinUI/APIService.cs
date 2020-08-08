using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using eProdaja.Model;
namespace eProdaja.WinUI
{
    public class APIService
    {
        private string _route = null;
        public APIService(string r)
        {
            _route = r;
        }

        public async Task<T> Get<T>(object rikvest)
        {
            var url = $"{Properties.Settings.Default.APIurl}/{_route}";

            if (rikvest != null)
            {
                url += "?"; //query string pocinje 
                url += await rikvest.ToQueryString();  //kreiranje kveri stringa, posebna klasa.
            }
            var result = await url.GetJsonAsync<T>();
            return result;
            
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIurl}/{_route}/{id}";

            return await url.GetJsonAsync<T>() ;
            

        }
        public async Task<T> Insert<T>(object rikvest)
        {
            var url = $"{Properties.Settings.Default.APIurl}/{_route}";
            return await url.PostJsonAsync(rikvest).ReceiveJson<T>();
        }
        public async Task<T> Update<T>(object id,object rikvest)
        {
            var url = $"{Properties.Settings.Default.APIurl}/{_route}/{id}";
            return await url.PutJsonAsync(rikvest).ReceiveJson<T>();
        }

    }
}
