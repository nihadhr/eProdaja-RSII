using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.WebAPI.Services
{
    public interface ICRUD<TModel,TSearchRequest,TInsert,TUpdate>
    {
        TModel Insert(TInsert request);
        TModel Update(int id, TUpdate request); 
    }
}
