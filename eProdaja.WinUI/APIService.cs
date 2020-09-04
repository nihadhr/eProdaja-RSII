using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using eProdaja.Model;
using System.Windows.Forms;

namespace eProdaja.WinUI
{
    public class APIService
    {
        private string _route = null;
        public static string Username { get; set; }
        public static string Password { get; set; }
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object rikvest)
        { 
            var url = $"{Properties.Settings.Default.APIurl}/{_route}";

            if (rikvest != null)
            {
                url += "?"; //query string pocinje 
                url += await rikvest.ToQueryString();  //kreiranje kveri stringa, posebna klasa sa fjom.
            }
            var result = await url.WithBasicAuth(Username,Password).GetJsonAsync<T>();
            return result;
            
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIurl}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>() ;
            
        }
        public async Task<T> Insert<T>(object rikvest)
        {
            var url = $"{Properties.Settings.Default.APIurl}/{_route}";
            //return await url.WithBasicAuth(Username, Password).PostJsonAsync(rikvest).ReceiveJson<T>();
            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(rikvest).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }
        public async Task<T> Update<T>(object id,object rikvest)
        {
            var url = $"{Properties.Settings.Default.APIurl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).PutJsonAsync(rikvest).ReceiveJson<T>();
        }

    }
}
