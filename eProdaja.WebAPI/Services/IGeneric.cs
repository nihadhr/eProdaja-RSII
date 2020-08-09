using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.WebAPI.Services
{
    public interface IGeneric<TModel,TSearchRequest>
    {
        public List<TModel> Get(TSearchRequest request);
        public TModel GetById(int id);

    }
}
