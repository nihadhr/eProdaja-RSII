using eProdaja.Model.Database;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Model.Services
{
    public interface IKorisnik
    {
        public List<Model.Korisnici> Get(KorisniciSearchRequest request);
        public Model.Korisnici Insert(KorisniciInsert request);
        public Model.Korisnici GetById(int id); 
        public Model.Korisnici Update(int id,KorisniciInsert rikvest);
        public Model.Korisnici Authenticiraj(string username, string pass);
        public Model.Korisnici Delete(int id);
    }
}
