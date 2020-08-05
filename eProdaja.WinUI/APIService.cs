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
                url += await rikvest.ToQueryString();
            }
            var result = await url.GetJsonAsync<T>();
            return result;
            
        }
    }
}
