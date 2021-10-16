using Api_Libreria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Libreria.Services.interfaces
{
   public  interface ILibroService
    {
        public List<LibroEntity> GetLibros();

        public LibroEntity AddLibro(LibroEntity LibroItem);

        public LibroEntity UpdateLibro(string id, LibroEntity LibroItem);

        public string DeleteLibro(string id);
    }
}
