using Api_Libreria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Libreria.Services.interfaces
{
   public  interface IAutorService
    {
        public List<AutorEntity> GetAutores();
        int GetMaxIdAutores();

        public AutorEntity GetAutorByiD(int id);

        public AutorEntity AddAutor(AutorEntity AutorItem);

        public AutorEntity UpdateAutor(int id, AutorEntity AutorItem);

        public Boolean DeleteAutor(int id);



    }
}
