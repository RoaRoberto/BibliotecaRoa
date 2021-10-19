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
        public int GetTotalLibros();
        int GetMaxIdLibros();

        public LibroEntity GetLibroByiD(int id);

        public LibroEntity AddLibro(LibroEntity LibroItem);

        public LibroEntity UpdateLibro(int id, LibroEntity LibroItem);

        public Boolean DeleteLibro(int id);



    }
}
