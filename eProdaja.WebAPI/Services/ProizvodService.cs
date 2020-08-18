using AutoMapper;
using eProdaja.Model;
using eProdaja.Model.Database;
using eProdaja.Model.Requests;
using eProdaja.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Model.Services
{
    public class ProizvodService : GenericCRUDService<Model.Proizvod, Database.Proizvodi, Requests.ProizvodSearchRequest, Requests.ProizvodUpsertRequest, Requests.ProizvodUpsertRequest>, IGeneric<Proizvod,Requests.ProizvodSearchRequest>
    {
        private eProdajaContext _database;
        private readonly IMapper _mapper;
        public ProizvodService(eProdajaContext database, IMapper mapper) : base(database, mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        public override List<Proizvod> Get(ProizvodSearchRequest request)
        {
            var list = _database.Set<Proizvodi>().AsQueryable();
            if (request?.VrstaId.HasValue == true)
            {
                list = list.Where(a => a.VrstaId == request.VrstaId);
            }
            list = list.OrderBy(a => a.Naziv);
            var listreturn = list.ToList();
            return _mapper.Map<List<Model.Proizvod>>(listreturn);

        }
        public override Proizvod GetById(int id)
        {
            return base.GetById(id);
        }
    }


}
