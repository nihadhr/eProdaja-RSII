﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Model;
using eProdaja.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.WebAPI.Controllers
{
    public class UlogeController : GenericController<Model.Uloge, object>
    {
        public UlogeController(IGeneric<Uloge, object> service) : base(service)
        {

        }

    }
}