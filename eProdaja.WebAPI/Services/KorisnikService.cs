using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Model.Database;
using AutoMapper;
using eProdaja.Model.Requests;
using eProdaja.WebAPI.Exceptions;

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
        public List<Model.Korisnici> Get(KorisniciSearchRequest request){

            var list = _database.Korisnici.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Ime))
            {
                list = list.Where(a => a.Ime.StartsWith(request.Ime));
            }
            if (!string.IsNullOrWhiteSpace(request.Prezime))
            {
                list = list.Where(a => a.Prezime.StartsWith(request.Prezime));
            }
            if (!string.IsNullOrWhiteSpace(request.KorisnickoIme))
            {
                list = list.Where(a => a.Prezime.StartsWith(request.KorisnickoIme));
            }

            return _mapper.Map<List<Model.Korisnici>>(list.ToList());

        }

        public Model.Korisnici Insert(KorisniciInsert request)
        {
            var obj = _mapper.Map<Database.Korisnici>(request);
            if(request.Password != request.PasswordConfirmation)
            {
                throw new UserException("Lozinke se ne poklapaju !");
            } 
            obj.LozinkaHash = "test1";
            obj.LozinkaSalt = "test2";
            _database.Korisnici.Add(obj);
            _database.SaveChanges();
            return _mapper.Map<Model.Korisnici>(obj);
        }

        public Korisnici GetById(int id)
        {
            var obj = _database.Korisnici.Find(id);
            return _mapper.Map<Model.Korisnici>(obj);
        }

        public Korisnici Update(int id,KorisniciInsert rikvest)
        {
            var obj = _database.Korisnici.Find(id);
            //_database.Korisnici.Attach(obj);
            //_database.Korisnici.Update(obj);
            if (rikvest.Password != rikvest.PasswordConfirmation && rikvest.Password.Length !=0)
            {
                throw new UserException("Lozinke se ne poklapaju !");
            } 
            //hashing pass

            //obj = _mapper.Map<Database.Korisnici>(rikvest);
            _mapper.Map(rikvest, obj);
            obj.LozinkaHash = "test1";
            obj.LozinkaSalt = "test2";
            _database.SaveChanges();
            return _mapper.Map<Model.Korisnici>(obj);
        }
    }
}
