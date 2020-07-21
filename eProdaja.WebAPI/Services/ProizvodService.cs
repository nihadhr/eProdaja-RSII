using eProdaja.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Model.Services
{
    public class ProizvodService:IProizvod 
    {
        public ActionResult<IEnumerable<Proizvod>> Get()
        {
            var list = new List<Proizvod>() { new Proizvod() { Naziv="Laptop",ProizvodID=1},
                                            new Proizvod() { Naziv="Mobitel",ProizvodID=2} };
            return list;
        }
    }
}
