using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Model.Database;
using AutoMapper;
using eProdaja.Model.Requests;

namespace eProdaja.Model.Services
{
    public class KorisnikService : IKorisnik
    {
        private eProdajaContext _database;
        private readonly IMapper _mapper;
        public KorisnikService(eProdajaContext db,IMapper mapper)
        {
            _database = db;
            _mapper = mapper;
        }
        public List<Model.Korisnici> Get(){

            var list= _database.Korisnici.ToList();

            return _mapper.Map<List<Model.Korisnici>>(list);

        }

        public Model.Korisnici Insert(KorisniciInsert request)
        {
            var obj = _mapper.Map<Database.Korisnici>(request);
            if(request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Lozinke se ne poklapaju !");
            }
            obj.LozinkaHash = "test1";
            obj.LozinkaSalt = "twst2";
            _database.Korisnici.Add(obj);
            _database.SaveChanges();
            return _mapper.Map<Model.Korisnici>(obj);
        }
    }
}
