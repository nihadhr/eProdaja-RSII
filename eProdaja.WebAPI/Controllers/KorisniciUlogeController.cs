using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using eProdaja.Model;
using eProdaja.Model.Services;
using eProdaja.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciUlogeController : ControllerBase
    {
       private IKorisniciUloge _korisnik { get; set; }
        public KorisniciUlogeController(IKorisniciUloge korisnik)
        {
       
            _korisnik = korisnik;
        }
    
            [HttpGet]
            public ActionResult<List<Model.KorisniciUloge>> Get(int ID)
            {
            return _korisnik.Get(ID);
        }
        }
    
}
