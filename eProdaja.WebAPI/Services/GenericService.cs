using AutoMapper;
using eProdaja.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.WebAPI.Services
{
    public class GenericService<TModel,TDatabase,TSearchRequest> : IGeneric<TModel,TSearchRequest>where TDatabase: class
    {
        private eProdajaContext _database;
        private IMapper _mapper;
        public GenericService(eProdajaContext database, IMapper mapper)
        {
            _mapper = mapper;
            _database = database;
        }

        public List<TModel> Get(TSearchRequest request)
        {
            var list = _database.Set<TDatabase>().ToList();
            return _mapper.Map<List<TModel>>(list);
        }

        public TModel GetById(int id)
        {
            var obj = _database.Set<TDatabase>().Find(id);
            return _mapper.Map<TModel>(obj);
        }
    }
}
