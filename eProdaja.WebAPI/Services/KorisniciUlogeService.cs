using AutoMapper;
using eProdaja.Model.Database;
using eProdaja.Model.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.WebAPI.Services
{
    public class KorisniciUlogeService:IKorisniciUloge
    {
        private eProdajaContext _database;
        private readonly IMapper _mapper;
        public KorisniciUlogeService(eProdajaContext db,IMapper map)
        {
            _database = db;
            _mapper = map;
        }

        public List<Model.KorisniciUloge> Get(int id)
        {
            var list=_database.KorisniciUloge.Where(a => a.KorisnikId == id);
            return _mapper.Map<List<Model.KorisniciUloge>>(list);
        }
    }
}
