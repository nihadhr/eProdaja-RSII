using AutoMapper;
using eProdaja.Model.Database;
using eProdaja.WebAPI.Mappers;
using eProdaja.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.WebAPI.Services
{
    public class GenericCRUDService<TModel, TDatabase, TSearchRequest, TInsert, TUpdate> : GenericService<TModel, TDatabase, TSearchRequest>, ICRUD<TModel, TSearchRequest, TInsert, TUpdate> where TDatabase:class
    {
        public GenericCRUDService(eProdajaContext database, IMapper mapper) : base(database, mapper)
        {

        }

        public virtual TModel Insert(TInsert request)
        {
            var obj = _mapper.Map<TDatabase>(request);
            _database.Set<TDatabase>().Add(obj);
            _database.SaveChanges();
            return _mapper.Map<TModel>(obj);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var obj = _database.Set<TDatabase>().Find(id);
            _database.Set<TDatabase>().Attach(obj);
            _database.Set<TDatabase>().Update(obj);
            _mapper.Map(request, obj);
            _database.SaveChanges();
            return _mapper.Map<TModel>(obj);
        }
    }
}
