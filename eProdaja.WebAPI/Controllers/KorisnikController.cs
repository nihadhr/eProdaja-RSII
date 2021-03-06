﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.Services;
using Microsoft.AspNetCore.Authorization;
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
        public ActionResult<List<Model.Korisnici>> Get([FromQuery]KorisniciSearchRequest request)
        {
            return _korisnik.Get(request);
        }
        [HttpGet("{id}")]
        public Model.Korisnici GetById(int id)
        {
            return _korisnik.GetById(id);
        }
        [HttpPut("{id}")]
        public Model.Korisnici Update(int id,[FromBody]KorisniciInsert rikvest)
        {
            return _korisnik.Update(id, rikvest);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public Model.Korisnici Insert(KorisniciInsert request)
        {
            return _korisnik.Insert(request);
        }
        [HttpDelete("{id}")]
        public Model.Korisnici Delete(int id)
        {
          return _korisnik.Delete(id);
        }

    } 
}