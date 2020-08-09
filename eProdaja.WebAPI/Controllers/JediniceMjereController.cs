using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Model;
using eProdaja.Model.Database;
using eProdaja.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.WebAPI.Controllers
{
    public class JediniceMjereController : GenericController<Model.JediniceMjere,Model.Database.JediniceMjere, object>
    {
        public JediniceMjereController(IGeneric<Model.JediniceMjere, object> service) : base(service)
        {

        }
    }
}