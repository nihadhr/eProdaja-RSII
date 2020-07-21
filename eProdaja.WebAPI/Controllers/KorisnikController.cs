using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Model.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase 
    {
        private IKorisnik _korisnik;
        public KorisnikController(IKorisnik korisnik)
        {
            _korisnik = korisnik;
        }
        [HttpGet]
        public ActionResult<List<Model.Korisnici>> Get()
        {
            return _korisnik.Get();
        }
        [HttpPost]
        public Model.Korisnici Insert(KorisniciInsert request)
        {
            return _korisnik.Insert(request);
        }

    } 
}