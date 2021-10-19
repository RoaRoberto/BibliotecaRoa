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
    public class Autoreservice : IAutorService
    {
        private readonly MyDbContext _myDbContext;

        public Autoreservice(MyDbContext myDbContext, IConfiguration configuration)
        {
            this._myDbContext = myDbContext;
        }
        public AutorEntity AddAutor(AutorEntity AutorItem)
        {
           
            
            AutorItem.Id = GetMaxIdAutores() + 1;
            var x = _myDbContext.Autores.Add(AutorItem);
            _myDbContext.SaveChanges();
            return AutorItem;
        }

        public bool DeleteAutor(int id)
        {
            var entity = _myDbContext.Autores.Find(id);
            if (entity != null)
            {
                var x = _myDbContext.Autores.Remove(entity);
                _myDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<AutorEntity> GetAutores()
        {
            return _myDbContext.Autores.ToList();
        }

        public AutorEntity GetAutorByiD(int id)
        {

          
            return _myDbContext.Autores.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }

        public int GetMaxIdAutores()
        {
            try
            {
                var x = _myDbContext.Autores.Max(i => i.Id);
                return x;
            }
            catch (Exception)
            {

                return 0;
            }
            
        }

      

        public AutorEntity UpdateAutor(int id, AutorEntity AutorItem)
        {

            var original = _myDbContext.Autores.Find(id);


            if (original != null)
            {
                _myDbContext.Entry(original).CurrentValues.SetValues(AutorItem);
                _myDbContext.SaveChanges();
            }
                return AutorItem;
            }

       
    }
    }
