using Api_Libreria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Libreria.Services.interfaces
{
   public  interface ICiudadService
    {
        public List<CiudadEntity> GetCiudades();

        public CiudadEntity GetCiudadByiD(int id);

    }
}
