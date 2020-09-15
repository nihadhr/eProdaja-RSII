using eProdaja.Model;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eProdaja.MobileApp
{
    public class APIService
    {
        private string _route = null;
        public static string Username { get; set; }
        public static string Password { get; set; }
#if DEBUG
        //private string _apiURL = "https://localhost:44318/api";  //with https
          private string _apiURL = "http://localhost:57637/api";  //zbog certifikata.
#endif
#if RELEASE
        private string _apiURL="https://mysite/api";
#endif
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object rikvest)
        {
            var url = $"{_apiURL}/{_route}";
            try
            {
                if (rikvest != null)
                     {
                        url += "?"; //query string pocinje 
                        url += await rikvest.ToQueryString();  //kreiranje kveri stringa, posebna klasa sa fjom.
                     }
                   
               return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                   
            }
            catch (FlurlHttpException ex)
            {
                if(ex.Call.HttpStatus==System.Net.HttpStatusCode.Unauthorized)
               await Application.Current.MainPage.DisplayAlert("Greška","Niste autorizovani za ovu akciju !","OK");
            throw;
            }

        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiURL}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

        }
        public async Task<T> Insert<T>(object rikvest)
        {
            var url = $"{_apiURL}/{_route}";
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

                await Application.Current.MainPage.DisplayAlert("Greška","Niste autorizovani za ovu akciju !","OK");
                return default(T);
            }

        }
        public async Task<T> Update<T>(object id, object rikvest)
        {
            var url = $"{_apiURL}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).PutJsonAsync(rikvest).ReceiveJson<T>();
        }

    }
}
