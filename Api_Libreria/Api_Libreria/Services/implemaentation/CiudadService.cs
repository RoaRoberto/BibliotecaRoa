using Api_Libreria.Context;
using Api_Libreria.Model;
using Api_Libreria.Services.interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Libreria.Services.implemaentation
{
    public class CiudadService : ICiudadService
    {
        private readonly MyDbContext _myDbContext;

        public CiudadService(MyDbContext myDbContext, IConfiguration configuration)
        {
            this._myDbContext = myDbContext;
        }


        public List<CiudadEntity> GetCiudades()
        {
            return _myDbContext.Ciudades.ToList();
        }

        public CiudadEntity GetCiudadByiD(int id)
        {


            return _myDbContext.Ciudades.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }




    }
}
