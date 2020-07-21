using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Model;
using eProdaja.Model.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Model.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        private readonly IProizvod _proizvod;
        public ProizvodController(IProizvod proizvod)
        {
            _proizvod = proizvod;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Proizvod>> Get()
        {   
            var list=_proizvod.Get();
            return list;
        }

        [HttpGet("{id}")]
        public ActionResult<Proizvod> GetById(int id)
        {
            var item = new Proizvod()
            {
                ProizvodID = 1,
                Naziv = "laptop"
            };
            return item;
        }
        [HttpPost]
        public Proizvod Insert(Proizvod p)
        {
            return new Proizvod()
            {
                ProizvodID = -1,
                Naziv = p.Naziv
            };
        }
        [HttpPut("{id}")]
        public Proizvod Update(int id,Proizvod p)
        {
            return new Proizvod
            {
                ProizvodID = -1,
                Naziv = p.Naziv
            };
        } 

    }
}