using AutoMapper;
using eProdaja.Model.Database;
using eProdaja.Model.Requests;
using eProdaja.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.WebAPI.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Korisnici, Model.Korisnici>();
            CreateMap<Korisnici, KorisniciInsert>().ReverseMap();
            CreateMap<JediniceMjere, Model.JediniceMjere>();
            CreateMap<VrsteProizvoda, Model.VrsteProizvoda>();
        }
    }
}
