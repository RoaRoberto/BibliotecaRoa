using Api_Libreria.Context;
using Api_Libreria.Model;
using Api_Libreria.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Libreria.Services.implemaentation
{
    public class LibroService : ILibroService
    {
        private readonly MyDbContext _myDbContext;
        private readonly int maximoLibros;

        public LibroService(MyDbContext myDbContext, IConfiguration configuration)
        {
            this._myDbContext = myDbContext;
            maximoLibros = Convert.ToInt32( configuration["maximaCantidadLibros"]);
        }
        public LibroEntity AddLibro(LibroEntity LibroItem)
        {
            var total = GetTotalLibros();
            if (total==maximoLibros)
            {
                throw new Exception("No es posible registrar el libro, se alcanzó el máximo permitido");
            }
            LibroItem.Id = GetMaxIdLibros() + 1;
            var x = _myDbContext.Libros.Add(LibroItem);
            _myDbContext.SaveChanges();
            return LibroItem;
        }

        public bool DeleteLibro(int id)
        {
            var entity = _myDbContext.Libros.Find(id);
            if (entity != null)
            {
                var x = _myDbContext.Libros.Remove(entity);
                _myDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<LibroEntity> GetLibros()
        {
            return _myDbContext.Libros.Include(b => b.Autor).ToList();
        }

        public LibroEntity GetLibroByiD(int id)
        {

          
            return _myDbContext.Libros.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }

        public int GetMaxIdLibros()
        {
            try
            {
                var x = _myDbContext.Libros.Max(i => i.Id);
                return x;
            }
            catch (Exception)
            {

                return 0;
            }
            
        }

        public int GetTotalLibros()
        {
            return _myDbContext.Libros.Count();

        }

        public LibroEntity UpdateLibro(int id, LibroEntity LibroItem)
        {

            var original = _myDbContext.Libros.Find(id);


            if (original != null)
            {
                _myDbContext.Entry(original).CurrentValues.SetValues(LibroItem);
                _myDbContext.SaveChanges();
            }
                return LibroItem;
            }
        }
    }
