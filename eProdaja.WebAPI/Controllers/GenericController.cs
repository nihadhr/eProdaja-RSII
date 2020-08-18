using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TModel,TSearchRequest> : ControllerBase
    {
        private readonly IGeneric<TModel,TSearchRequest> _service;
        public GenericController(IGeneric<TModel,TSearchRequest> service)
        {
            _service = service;
        }
    
        [HttpGet]
        public List<TModel> Get([FromQuery]TSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{id}")]
        public TModel GetById(int id)
        {
            return _service.GetById(id); 
        }


    }
}