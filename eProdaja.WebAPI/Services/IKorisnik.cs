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
        public List<Model.Korisnici> Get();
        public Model.Korisnici Insert(KorisniciInsert request);
    }
}
