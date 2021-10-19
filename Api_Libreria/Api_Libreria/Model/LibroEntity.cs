using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Libreria.Model
{
    [Table ("LIBRO")]
    public class LibroEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("TITULO")]
        public string Titulo { get; set; }

        [Column("ANHO")]
        public int Anho { get; set; }

        [Column("GENERO")]
        public string Genero { get; set; }

        [Column("NROPAGINAS")]
        public int NroPaginas { get; set; }


        //Foreign key para Autor
        [Column("AUTORID")]
        public int AutorId { get; set; }
        public AutorEntity Autor { get; set; }
    }
}
