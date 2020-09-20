using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.WebAPI.Services
{
    public interface IKorisniciUloge
    {
        public List<Model.KorisniciUloge> Get(int id);
    }
}
