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
            CreateMap<Proizvodi, Model.VrsteProizvoda>();  //vrlo upitno zasto je tu
            CreateMap<Proizvodi, Model.Proizvod>();
            CreateMap<ProizvodUpsertRequest, Proizvodi>();
            CreateMap<Uloge, Model.Uloge>();
            CreateMap<KorisniciUloge, Model.KorisniciUloge>();
        }
    }
}
