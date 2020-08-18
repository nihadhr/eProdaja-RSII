using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.Services;
using eProdaja.WebAPI.Controllers;
using eProdaja.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace eProdaja.Model.Controllers
{
    public class ProizvodController :GenericCRUDController<Model.Proizvod, Requests.ProizvodSearchRequest,Requests.ProizvodUpsertRequest,Requests.ProizvodUpsertRequest>
    {
        public ProizvodController(ICRUD<Proizvod, ProizvodSearchRequest,ProizvodUpsertRequest,ProizvodUpsertRequest> service,IGeneric<Proizvod,ProizvodSearchRequest>_base) : base(service,_base)
        {
           
        }
       

    }
}