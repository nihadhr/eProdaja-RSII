using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Model.Database;
using AutoMapper;
using eProdaja.Model.Requests;
using eProdaja.WebAPI.Exceptions;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

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

            return _mapper.Map<List<Model.Korisnici>>(list.Include(a=>a.KorisniciUloge).ToList());

        }
        public Model.Korisnici Authenticiraj(string username, string pass)
        {
            var user = _database.Korisnici.Include(a=>a.KorisniciUloge).ThenInclude(s=>s.Uloga).FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Korisnici>(user);
                }
            }
            return null;
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt,string pass)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm alg = HashAlgorithm.Create("SHA1");
            byte[] inArray = alg.ComputeHash(dst);
            return Convert.ToBase64String(inArray);

        }
        public Model.Korisnici Insert(KorisniciInsert request) 
        {
            var obj = _mapper.Map<Database.Korisnici>(request);
            if(request.Password != request.PasswordConfirmation)
            {
                throw new UserException("Lozinke se ne poklapaju !");
            }
            obj.LozinkaSalt = GenerateSalt();
            obj.LozinkaHash = GenerateHash(obj.LozinkaSalt, request.Password); 
            _database.Korisnici.Add(obj);
            _database.SaveChanges();
            foreach(var x in request.Uloge)
            {
                _database.KorisniciUloge.Add(new Database.KorisniciUloge()
                {
                    DatumIzmjene = DateTime.Now,
                    UlogaId=x,
                    KorisnikId=obj.KorisnikId
                });
            }
            _database.SaveChanges();
            return _mapper.Map<Model.Korisnici>(obj);
        }

        public Korisnici GetById(int id) 
        {
            var obj = _database.Korisnici.Find(id);
            return _mapper.Map<Model.Korisnici>(obj);
        }
        public Korisnici Delete(int id)
        {
            var obj = _database.Korisnici.Find(id);
       
            var list = _database.KorisniciUloge.Where(a => a.KorisnikId == obj.KorisnikId);
            _database.KorisniciUloge.RemoveRange(list);
            _database.SaveChanges();
            _database.Korisnici.Remove(obj);
            _database.SaveChanges();
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
            obj.LozinkaSalt = GenerateSalt();
            obj.LozinkaHash = GenerateHash(obj.LozinkaSalt, rikvest.Password);
            foreach (var x in rikvest.Uloge)
            {
                var list = _database.KorisniciUloge.Where(a => a.KorisnikId == obj.KorisnikId);
                _database.KorisniciUloge.RemoveRange(list);
                _database.KorisniciUloge.Add(new Database.KorisniciUloge()
                {
                    DatumIzmjene = DateTime.Now,
                    UlogaId = x,
                    KorisnikId = obj.KorisnikId
                });
            }
            _database.SaveChanges();
            return _mapper.Map<Model.Korisnici>(obj);
        }
    }
}
