using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace eProdaja.WebAPI.Controllers
{

    public class GenericCRUDController<TModel, TSearchRequest, TInsert, TUpdate> : GenericController<TModel, TSearchRequest>
    {
        private readonly ICRUD<TModel, TSearchRequest, TInsert, TUpdate> _service = null;
        public GenericCRUDController(ICRUD<TModel, TSearchRequest, TInsert, TUpdate> service,IGeneric<TModel,TSearchRequest>_base) : base(_base) {
            _service = service;

        }
        [HttpPost]
        public TModel Insert(TInsert request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public TModel Update(int id,TUpdate request)
        {
            return _service.Update(id, request);
        }
    }
}