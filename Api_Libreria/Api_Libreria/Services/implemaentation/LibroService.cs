using Api_Libreria.Context;
using Api_Libreria.Model;
using Api_Libreria.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Libreria.Services.implemaentation
{
    public class LibroService : ILibroService
    {
        private readonly MyDbContext _myDbContext;

        public LibroService(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }
        public LibroEntity AddLibro(LibroEntity LibroItem)
        {
            throw new NotImplementedException();
        }

        public string DeleteLibro(string id)
        {
            throw new NotImplementedException();
        }

        public List<LibroEntity> GetLibros()
        {
            return _myDbContext.libros.ToList();
          //  return null;
        }

        public LibroEntity UpdateLibro(string id, LibroEntity LibroItem)
        {
            throw new NotImplementedException();
        }
    }
}
