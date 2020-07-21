using eProdaja.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Model.Services
{
    public interface IProizvod
    {
        public ActionResult<IEnumerable<Proizvod>> Get();

    }
}
